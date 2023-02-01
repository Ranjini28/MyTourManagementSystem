namespace MyTourManagementMVC.Helper
{
    public class MyTourAPI
    {
        public HttpClient Initial()
        {
            var client=new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5280");
            return client;
        }
    }
}
