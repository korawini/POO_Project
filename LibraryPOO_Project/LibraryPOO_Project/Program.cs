using System.Net;
using LibraryPOO_Project;
using System.Text.Json;
wrapper wrapper = new wrapper();
library lb = new library();
wrapper.LoadData(lb);
wrapper.RunMenu(lb);


wrapper.SaveData(lb);