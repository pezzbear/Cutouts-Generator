using ImageMagick;
using UITimer = System.Windows.Forms.Timer;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Drawing.Drawing2D;
using System.Collections.Specialized;
using Newtonsoft.Json;

namespace Cutouts_Generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string[] frameFilePaths;

        private bool sourceImgImported = false;

        private string coverageFilePath;

        private List<MagickImage> frameImages = new List<MagickImage>();

        private MagickImageCollection nftExportCollection = new MagickImageCollection();

        private int numberOfImages = 5;

        private int sourceWidth;

        private int sourceHeight;

        private int numberOfFrames;

        private int gifSize = 200;

        private int delay = 6;

        private int frame;

        private List<(int x, int y)> coordList = new List<(int x, int y)>();

        private Random random = new Random();

        private UITimer frameRateTimer;

        private int xCoord = 0;
        private int yCoord = 0;

        private string filePath = "C:\\Users\\edanz\\Documents\\cutouts dev folder\\Export";

        private List<(int x, int y)> oneOfOneCoords = new List<(int x, int y)>();

        private int coordListIndex = -1;

        private string nftSymbol = "CTS";

        public void initTimer()
        {
            frameRateTimer = new UITimer();
            frameRateTimer.Interval = Convert.ToInt32((1f / delay) * 1000);
            frameRateTimer.Tick += new EventHandler(frameRateTimer_Tick);
            frameRateTimer.Start();
        }

        //This is where the image is shown
        private Bitmap image;
        private void frameRateTimer_Tick(object sender, EventArgs e)
        {
            var coverageImg = rbtn_coverageImg.Checked;
            var nftCoverage = rbtn_nftCoverage.Checked;
            
            image = new Bitmap(frameFilePaths[frame]);
            pBox_display.Image = image;

            if(coverageImg)
            {
                if (coverageFilePath != null)
                {
                    image = new Bitmap(coverageFilePath);
                    pBox_display.Image = image;
                }
            }

            if (nftCoverage)
            {

            }

            frame++;
            if (frame == frameFilePaths.Length)
            {
                frame = 0;
            }

        }

        private void CreateFrameImages(string[] frameFilePaths)
        {
            frameImages.Clear();
            foreach (string filePaths in frameFilePaths)
            {
                var img = new MagickImage(filePaths);
                frameImages.Add(img);
                sourceWidth = img.Width;
                sourceHeight = img.Height;
            }
        }


        private void btn_openSourceImg_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\Users\\edanz\\Documents\\cutouts dev folder";
                openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp; *.tif; *.tiff)|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.tif;*.tiff|All Files (*.*)|*.*\r\n";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    frameFilePaths = openFileDialog.FileNames;
                }
            }

            if (frameFilePaths != null)
            {

                numberOfFrames = frameFilePaths.Length;

                CreateFrameImages(frameFilePaths);

                initTimer();

                sourceImgImported = true;
            }

            //check if the source image and the coverage image have been imported and if so, enable the generate button
            if (coverageFilePath != null && sourceImgImported)
            {
                btn_generate.Enabled = true;
            }
        }

        private void btn_generate_Click(object sender, EventArgs e)
        {

            if(coverageFilePath == null)
            {
                MessageBox.Show("Select a Coverage Image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lbl_status.Text = "Generating! ( •_•)>⌐■-■";

            var count = 0;

            if (lst_coordList.Items.Count != 0)
            {
                var getX = 0;
                var getY = 0;

                foreach (var coord in lst_coordList.Items)
                {
                    string[] coords = coord.ToString().Split(',');

                    if (coords.Length == 2)
                    {
                        if (int.TryParse(coords[0], out getX) && int.TryParse(coords[1], out getY))
                        {
                            //add the coords to the list to check 
                            coordList.Add((getX, getY));

                            //create gif at the specified coords
                            foreach (var images in frameImages)
                            {
                                //create copies of the original magick frames 
                                var mgkImg = new MagickImage(images);

                                //crop the copies of the original magick frames and add them to the magick collection
                                Debug.WriteLine(xCoord.ToString() + " - " + yCoord.ToString());
                                mgkImg.Crop(new MagickGeometry(getX, getY, gifSize, gifSize));
                                mgkImg.RePage();

                                //add Img to collection
                                nftExportCollection.Add(mgkImg);
                                nftExportCollection[nftExportCollection.Count() - 1].AnimationDelay = (delay / 100);
                                nftExportCollection[nftExportCollection.Count() - 1].GifDisposeMethod = GifDisposeMethod.Previous;
                            }

                            //Generate Metadata
                            Generate_OffChain_Metadata(count, getX, getY, true);

                            //create gif pogu
                            nftExportCollection.Write(filePath + "\\" + count.ToString() + ".gif");
                            nftExportCollection.Clear();
                            count++;
                        }
                    }
                }
            }

            for (int i = 0; i < numberOfImages; i++)
            {
                bool genCoords = true;
                foreach (var images in frameImages)
                {
                    //create copies of the original magick frames 
                    var mgkImg = new MagickImage(images);

                    //choose a random set of coords and record those coords


                    while (genCoords)
                    {
                        xCoord = random.Next(mgkImg.Width - gifSize);
                        yCoord = random.Next(mgkImg.Height - gifSize);

                        if (coordList.Count == 0)
                        {
                            coordList.Add((xCoord, yCoord));
                            genCoords = false;
                        }
                        else
                        {
                            foreach (var coords in coordList)
                            {
                                if (xCoord != coords.x && yCoord != coords.y)
                                {
                                    genCoords = false;
                                }
                            }
                            genCoords = false;
                        }
                    }

                    //crop the copies of the original magick frames and add them to the magick collection
                    mgkImg.Crop(new MagickGeometry(xCoord, yCoord, gifSize, gifSize));
                    mgkImg.RePage();

                    //add Img to collection
                    nftExportCollection.Add(mgkImg);
                    nftExportCollection[nftExportCollection.Count() - 1].AnimationDelay = (delay / 100);
                    nftExportCollection[nftExportCollection.Count() - 1].GifDisposeMethod = GifDisposeMethod.Previous;
                }

                Generate_OffChain_Metadata(count, xCoord, yCoord, false);

                //create gif pogu
                nftExportCollection.Write(filePath + "\\" + count.ToString() + ".gif");
                nftExportCollection.Clear();
                count++;
            }

            lbl_status.Text = "Success. (⌐■_■)";
        }

        private void Generate_OffChain_Metadata(int count, int x, int y, bool isSelected)
        {
            var name = "";

            //create the name
            switch (count.ToString().Length)
            {
                case 1:
                    name = "000" + count.ToString();
                    break;

                case 2:
                    name = "00" + count.ToString();
                    break;

                case 3:
                    name = "0" + count.ToString();
                    break;
            }

            //create attributes
            var attributeX = new Attribute("X", x.ToString());
            var attributeY = new Attribute("Y", y.ToString());
            var isPreselected = new Attribute("preselected", isSelected.ToString());

            //Determine Coverate % and rank
            var getCoverage = Determine_Coverage(x, y);

            var coverage = new Attribute("coverage", getCoverage.ToString());

            var rank = new Attribute("Rank", Determine_Rank(getCoverage));

            var attributes = new List<Attribute> { attributeX, attributeY, isPreselected, coverage, rank };

            //create properties
            var files = new _File(count.ToString() + ".gif", "image/gif");
            List<_File> filesList = new List<_File>();
            filesList.Add(files);

            var properties = new _Properties(filesList, "image");

            //create the metadata obj
            Metadata metadata = new Metadata("Cutouts #" + name, nftSymbol, count.ToString() + ".gif", attributes, properties);

            //convert this jaunt to json

            string jsonString = metadata.ToJson();

            string path = filePath + "\\" + count.ToString() + ".json";

            File.WriteAllText(path, jsonString);

            Debug.WriteLine("Json Saved!");
        }

        private decimal Determine_Coverage(int x, int y)
        {
            //Do big image and math shish idk ¯\_(ツ)_/¯
            if(coverageFilePath != null)
            {
                decimal count = 0;

                //get the coverage img
                var mgkImg = new MagickImage(coverageFilePath);

                //crop the jaunt
                mgkImg.Crop(new MagickGeometry(x, y, gifSize, gifSize));

                mgkImg.RePage();

                //figure out how many squares are blue（・□・）

                //get the pixels
                var pixels = mgkImg.GetPixels();

                //loop through them
                for(var _y = 0; _y < gifSize; _y++)
                {
                    for (var _x = 0; _x < gifSize; _x++)
                    {
                        IMagickColor<ushort> getPixelColor = pixels[_x, _y].ToColor();

                        Color targetColor = Color.FromArgb(18, 143, 255);

                        int tColorConv = ColorTranslator.ToWin32(targetColor);

                        var tColorHex = string.Format("{0:X8}", tColorConv);

                        //check if pixel color matches the target color
                        if (getPixelColor.ToHexString().Equals("#128FFF"))
                        {
                            count++;
                        }
                    }

                }
                decimal coveragePercent = (count / (gifSize * gifSize));
                Debug.WriteLine("COUNT %: " + count.ToString());
                Debug.WriteLine("COVERAGE %: " + coveragePercent.ToString());
                return coveragePercent;

            }
            else
            {
                return -1m;
            }

        }

        private string Determine_Rank(decimal coverage)
        {
            return "";
        }

        private void numOfImg_ValueChanged(object sender, EventArgs e)
        {
            numberOfImages = Convert.ToInt32(num_numOfImg.Value);
        }

        private void gifSize_ValueChanged(object sender, EventArgs e)
        {
            gifSize = Convert.ToInt32(num_gifSize.Value);
        }

        private void delay_ValueChanged(object sender, EventArgs e)
        {
            delay = Convert.ToInt32(num_delay.Value);

            if (frameRateTimer != null)
            {
                if (frameRateTimer.Enabled)
                {
                    frameRateTimer.Interval = Convert.ToInt32((1f / delay) * 1000);
                }
            }

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            pnl_controls.Location = new Point(this.ClientSize.Width - pnl_controls.Width - 8, 8);

            pnl_controls.Size = new Size(pnl_controls.Width, this.ClientSize.Height - 16);

            pBox_display.Size = new Size(pnl_controls.Location.X - 8, pnl_controls.Location.Y + pnl_controls.Height - 8);


        }

        private void btn_setExportPath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    filePath = folderBrowserDialog.SelectedPath;
                    txt_exportFilePath.Text = filePath;
                }
            }
        }

        private bool coordsAreValid(int x, int y)
        {
            if (x < 0 || x > sourceWidth - gifSize) return false;
            if (y < 0 || y > sourceHeight - gifSize) return false;

            return true;
        }

        private void btn_addCoord_Click(object sender, EventArgs e)
        {
            if (frameImages.Count != 0)
            {
                int getX = Convert.ToInt32(num_xCoord.Value);
                int getY = Convert.ToInt32(num_yCoord.Value);

                //check if coords are valid

                if (!coordsAreValid(getX, getY)) return;

                if (oneOfOneCoords.Count < 0)
                {
                    oneOfOneCoords.Add((getX, getY));
                }
                else
                {
                    foreach (var coords in oneOfOneCoords)
                    {
                        if (getX == coords.x && getY == coords.y)
                        {
                            MessageBox.Show("Coord Already Added", "output", MessageBoxButtons.OK);
                            return;
                        }


                    }
                    oneOfOneCoords.Add((getX, getY));
                }

                //add the coord to the listbox
                lst_coordList.Items.Add(getX + ", " + getY);

                StringCollection coordCollection = new StringCollection();

                foreach (var coord in oneOfOneCoords)
                {
                    coordCollection.Add($"{coord.x},{coord.y}");
                }
            }
            else
            {
                MessageBox.Show("Please Import a Source Image or Images", "output", MessageBoxButtons.OK);
            }

        }

        private void btn_removeCoord_Click(object sender, EventArgs e)
        {
            var getX = 0;
            var getY = 0;

            if (coordListIndex != -1)
            {
                string[] coords = lst_coordList.GetItemText(lst_coordList.SelectedItem).Split(',');
                lst_coordList.Items.RemoveAt(lst_coordList.SelectedIndex);

                if (coords.Length == 2)
                {
                    if (int.TryParse(coords[0], out getX) && int.TryParse(coords[1], out getY))
                    {
                        (int x, int y) coordsToCheck = (getX, getY);
                        if (oneOfOneCoords.Contains(coordsToCheck))
                        {
                            oneOfOneCoords.Remove(coordsToCheck);
                        }
                    }
                }

            }
        }

        private void lst_coordList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Set the "selectedListItem" to whatever the user has selected from the list
            coordListIndex = lst_coordList.SelectedIndex;
        }

        private void btn_importCoordList_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Make sure that the coordinates are formatted correctly in the text file. \nExample: \n1,1\n2,2\n3,3", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            // Create an instance of OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set filter options and filter index
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            // Show the dialog and read selected file
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Create a StringCollection to store lines from the file
                StringCollection stringCollection = new StringCollection();

                // Read each line from the selected file and add it to the StringCollection
                using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        stringCollection.Add(line);
                    }
                }

                //set the listbox to have the text
                lst_coordList.Items.Clear();
                string[] coordsArray = new string[stringCollection.Count];
                stringCollection.CopyTo(coordsArray, 0);
                lst_coordList.Items.AddRange(coordsArray);

                // Print the lines from the StringCollection
                Debug.WriteLine("Lines from the selected file:");
                foreach (string line in stringCollection)
                {
                    Debug.WriteLine(line);
                }
            }
            else
            {
                Debug.WriteLine("No file selected.");
            }

        }

        private void btn_openCoverageImg_Click(object sender, EventArgs e)
        {
            

            var fileContent = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\Users\\edanz\\Documents\\cutouts dev folder";
                openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp; *.tif; *.tiff)|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.tif;*.tiff|All Files (*.*)|*.*\r\n";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    coverageFilePath = openFileDialog.FileNames[0];
                    Debug.WriteLine(coverageFilePath);
                }
            }

            //check if the source image and the coverage image have been imported and if so, enable the generate button
            if(coverageFilePath != null && sourceImgImported)
            {
                btn_generate.Enabled = true;
            } 
        }
    }
}
