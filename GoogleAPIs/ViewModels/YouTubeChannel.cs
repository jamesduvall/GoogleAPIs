using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoogleAPIs.ViewModels
{
    public class YouTubeChannel
    {
        public string ChannelId { get; set; }
        public string ChannelName { get; set; }
        public List<YouTubeVideo> Videos { get; set; }

        public YouTubeChannel() 
        {
            Videos = new List<YouTubeVideo>();
        }

        public YouTubeChannel (Google.Apis.YouTube.v3.Data.Channel youTubeChannel)
        {
            if(youTubeChannel != null)
            {       
                ChannelName = youTubeChannel.Snippet.Title;
                ChannelId = youTubeChannel.Id;
                Videos = new List<YouTubeVideo>();
            }                    
        }
    }
}