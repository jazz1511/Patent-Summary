using add_patent;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Google.Apis.Drive.v3;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Drive.v3.Data;
using System.Collections.Generic;
using Google.Apis.Util;
using System.IO;

namespace Patent_Summary
{
    public partial class Form_Base : Form
    {
        public Form_Base()
        {
            InitializeComponent();

            ////    Execute if not downloading from cloud.
            //
            //if (!System.IO.File.Exists("patent_data.xml"))
            //{
            //    XmlWriterSettings xmls = new XmlWriterSettings();
            //    xmls.Indent = true;
            //    xmls.Encoding = Encoding.UTF8;

            //    XmlWriter xmlw = XmlWriter.Create("patent_data.xml", xmls);
            //    xmlw.WriteStartDocument();
            //    xmlw.WriteStartElement("patents");
            //    xmlw.WriteEndDocument();
            //    xmlw.Close();
            //}
            //

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_AddNew form_AddNew = new Form_AddNew();
            form_AddNew.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.form_AddNew_FormClosed);
            DialogResult dialogResult = form_AddNew.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form_ViewData form_ViewData = new Form_ViewData();
            form_ViewData.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.form_ViewData_FormClosed);
            DialogResult dialogResult = form_ViewData.ShowDialog();
        }

        private async void form_AddNew_FormClosed(object sender, EventArgs eventArgs)
        {
            //  Check for the need of modification
            XmlDocument doc = new XmlDocument();
            doc.Load("temp_AddNew.xml");
            XmlNode root;
            if (doc.DocumentElement != null)
                root = doc.DocumentElement;
            else
                return;

            string flag;
            if (root.Attributes != null && root.Attributes["flag"] != null)
                flag = root.Attributes["flag"].InnerText;
            else
                flag = "0";

            if (flag == "0")
                return;
            else
            {
                const string pathToServiceAccountKey = @"cdm-npd-380811-37451a07dc18.json";
                string fileId;

                //  Authenticate connection to cloud
                var service = authenticate(pathToServiceAccountKey);

                //  Update the patent_data.xml file
                fileId = updateFile(service);

                //  Modify the patent_data.xml file
                XmlDocument doc2 = new XmlDocument();
                doc2.Load("patent_data.xml");
                XmlNode root2 = doc2.DocumentElement;

                XmlElement node = doc2.CreateElement("patent");

                string id = root.Attributes["id"]?.InnerText;
                string owner = root.Attributes["owner"]?.InnerText;
                string name = root.Attributes["name"]?.InnerText;
                string segment = root.Attributes["segment"]?.InnerText;

                XmlAttribute rootAttrib2 = doc2.CreateAttribute("id");
                rootAttrib2.Value = id;
                node.Attributes.Append(rootAttrib2);

                rootAttrib2 = doc2.CreateAttribute("owner");
                rootAttrib2.Value = owner;
                node.Attributes.Append(rootAttrib2);

                rootAttrib2 = doc2.CreateAttribute("name");
                rootAttrib2.Value = name;
                node.Attributes.Append(rootAttrib2);

                rootAttrib2 = doc2.CreateAttribute("segment");
                rootAttrib2.Value = segment;
                node.Attributes.Append(rootAttrib2);

                node.InnerXml = root.InnerXml;

                root2.AppendChild(node);
                doc2.Save("patent_data.xml");

                //  Update the modified patent_data.xml file
                uploadFile(fileId, service);
            }

            root.RemoveAll();
            doc.Save("temp_AddNew.xml");

            //  End of program




            //  Make changes to the patent_data.xml file

            ////  Update the patent_data.xml file to cloud.
            //var fileMetaData = new Google.Apis.Drive.v3.Data.File()
            //{
            //    Name = "patent_data.xml",
            //    Parents = new List<string>() { directoryId }
            //};
            ////string uploadedFileId;
            //await using (var fsSource = new FileStream("patent_data2.xml", FileMode.Open, FileAccess.Read))
            //{
            //    var request3 = service.Files.Create(fileMetaData, fsSource, "text/plain");
            //    request3.Fields = "*";
            //    var results = await request3.UploadAsync(CancellationToken.None);
            //    //uploadedFileId = request3.ResponseBody?.Id;
            //}


            //byte[] byteArray = System.IO.File.ReadAllBytes("patent_data2.xml");
            //var stream2 = new System.IO.MemoryStream(byteArray);
            //var uploadRequest = service.Files.Update(file, fileId, stream2, file.MimeType);
            ////uploadRequest.KeepRevisionForever = true;
            //uploadRequest.Upload();




            //    To retrieve directory Id of GDrive folder.

            //List<Google.Apis.Drive.v3.Data.File> result = new List<Google.Apis.Drive.v3.Data.File>();
            //FilesResource.ListRequest request2 = service.Files.List();
            //request2.Q = "name = 'data2.xml'";
            //FileList files = request2.Execute();
            //result.AddRange(files.Files);
            //int i = 0;
            //while (i < result.Count)
            //{
            //    //textBox1.Text = textBox1.Text + result[i].Name.ToString() + " " + result[i].Id.ToString() + " ";
            //    service.Files.Delete(result[i].Id).Execute();
            //    i++;
            //}


            //var fileMetaData = new Google.Apis.Drive.v3.Data.File()
            //{
            //    Name = "text.txt",
            //    Parents = new List<string> () { directoryId }
            //};

            //var request = service.Files.Get(directoryId);
            //var stream = new MemoryStream();
            //request.Download(stream);
            //string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            //using (System.IO.FileStream file = new System.IO.FileStream(path, System.IO.FileMode.Create, System.IO.FileAccess.Write))
            //{
            //    stream.WriteTo(file);
            //}

            //string uploadedFileId;
            //await using (var fsSource = new FileStream(uploadFileName, FileMode.Open, FileAccess.Read))
            //{
            //    var request = service.Files.Create(fileMetaData, fsSource, "text/plain");
            //    request.Fields = "*";
            //    var results = await request.UploadAsync(CancellationToken.None);

            //    if (results.Status == Google.Apis.Upload.UploadStatus.Failed)
            //    {

            //    }

            //    uploadedFileId = request.ResponseBody?.Id;
            //}

        }

        private void form_ViewData_FormClosed(object sender, FormClosedEventArgs e)
        {
            return;
        }

        public DriveService authenticate(string pathToServiceAccountKey)
        {
            var credential = GoogleCredential.FromFile(pathToServiceAccountKey).CreateScoped(DriveService.ScopeConstants.Drive);
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential
            });

            return service;
        }

        public string updateFile(DriveService service)
        {
            //  Declare some constants
            const string downloadFileName = "patent_data.xml";
            string fileId;

            //  Get File Id of the patent_data.xml file
            List<Google.Apis.Drive.v3.Data.File> fileResult = new List<Google.Apis.Drive.v3.Data.File>();
            FilesResource.ListRequest fileRequest = service.Files.List();
            fileRequest.Q = "name = 'patent_data.xml'";
            FileList files = fileRequest.Execute();
            fileResult.AddRange(files.Files);
            fileId = fileResult[0].Id.ToString();

            //  Download the patent_data.xml file to our folder
            var downloadRequest = service.Files.Get(fileId);
            var downloadStream = new System.IO.MemoryStream();
            downloadRequest.Download(downloadStream);
            string path = downloadFileName;
            using (System.IO.FileStream fileStream = new System.IO.FileStream(path, System.IO.FileMode.Create, System.IO.FileAccess.Write))
            {
                downloadStream.WriteTo(fileStream);
            }

            return fileId;
        }

        public async void uploadFile(string fileId, DriveService service)
        {
            //  Declare some constants
            const string uploadFileName = "patent_data.xml";
            const string directoryId = "16fT-TJtkPJ2b9Du3CmBRqxhzK8j2fSZ3";

            //Delete the existing file
            service.Files.Delete(fileId).Execute();

            // Upload the file
            var fileMetaData = new Google.Apis.Drive.v3.Data.File()
            {
                Name = uploadFileName,
                Parents = new List<string>() { directoryId }
            };
            await using (var fsSource = new FileStream(uploadFileName, FileMode.Open, FileAccess.Read))
            {
                var uploadRequest = service.Files.Create(fileMetaData, fsSource, "text/plain");
                uploadRequest.Fields = "*";
                var results = await uploadRequest.UploadAsync(CancellationToken.None);
            }

        }

        private async void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";

            bool verified = false;
            if (System.IO.File.Exists("developer_credentials.xml"))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("developer_credentials.xml");

                XmlNode root = doc.DocumentElement;

                if (root.InnerText == "H&7%~gH8")
                    verified = true;
            }

            //XmlWriterSettings xmls = new XmlWriterSettings();
            //xmls.Indent = true;
            //xmls.Encoding = Encoding.UTF8;

            //XmlWriter xmlw = XmlWriter.Create("developer_credentials.xml", xmls);
            //xmlw.WriteStartDocument();
            //xmlw.WriteStartElement("developer");
            //xmlw.WriteString("H&7%~gH8");
            //xmlw.WriteEndDocument();
            //xmlw.Close();

            if (!verified)
            {
                textBox1.Text = "You are not authorised.";
                return;
            }

            const string pathToServiceAccountKey = @"cdm-npd-380811-37451a07dc18.json";
            const string uploadFileName = "patent_data.xml";
            const string directoryId = "16fT-TJtkPJ2b9Du3CmBRqxhzK8j2fSZ3";
            string fileId;

            //  Authenticate connection to cloud
            var service = authenticate(pathToServiceAccountKey);

            //  Get File Id of the patent_data.xml file
            List<Google.Apis.Drive.v3.Data.File> fileResult = new List<Google.Apis.Drive.v3.Data.File>();
            FilesResource.ListRequest fileRequest = service.Files.List();
            fileRequest.Q = "name = 'patent_data.xml'";
            FileList files = fileRequest.Execute();
            fileResult.AddRange(files.Files);
            fileId = fileResult[0].Id.ToString();

            //  Delete file
            service.Files.Delete(fileId).Execute();

            // Upload the file
            var fileMetaData = new Google.Apis.Drive.v3.Data.File()
            {
                Name = uploadFileName,
                Parents = new List<string>() { directoryId }
            };
            await using (var fsSource = new FileStream(uploadFileName, FileMode.Open, FileAccess.Read))
            {
                var uploadRequest = service.Files.Create(fileMetaData, fsSource, "text/plain");
                uploadRequest.Fields = "*";
                var results = await uploadRequest.UploadAsync(CancellationToken.None);
            }

            textBox1.Text = "File successfully uploaded.";

        }
    }
}