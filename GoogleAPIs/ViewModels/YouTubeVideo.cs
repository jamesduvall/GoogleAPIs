using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoogleAPIs.ViewModels
{
    public class YouTubeVideo
    {
        public string VideoId { get; set; }
        public string ChannelName { get; set; }
        public string VideoName { get; set; }
        public string Description { get; set; }
        public DateTime? PublishedAt { get; set; }

        public YouTubeVideo(Google.Apis.YouTube.v3.Data.PlaylistItem youTubeVideo)
        {
            if(youTubeVideo != null)
            {
                this.VideoId = youTubeVideo.Snippet.ResourceId.VideoId;
                this.ChannelName = youTubeVideo.Snippet.ChannelTitle;
                this.VideoName = youTubeVideo.Snippet.Title;
                this.Description = youTubeVideo.Snippet.Description;
                this.PublishedAt = youTubeVideo.Snippet.PublishedAt;
            }
        }
    }
}