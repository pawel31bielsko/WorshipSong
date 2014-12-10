using System;
using WorshipSong.UI.Model;

namespace WorshipSong.UI.Design
{
    public class DesignDataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to create design time data

            var item = new DataItem("Lorem ipsum dolor sit amet enim.\n Etiam ullamcorper. Suspendisse a pellentesque dui, non felis.\n Maecenas malesuada elit lectus felis, malesuada ultricies.");
            callback(item, null);
        }
    }
}