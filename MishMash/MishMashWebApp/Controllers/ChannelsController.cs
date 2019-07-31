using System.Linq;
using MishMashWebApp.Models;
using MishMashWebApp.ViewModels.Channels;
using SIS.HTTP.Responses;
using SIS.MvcFramework.Attributes;

namespace MishMashWebApp.Controllers
{
    public class ChannelsController : BaseController
    {
        [HttpGet(Url = "/Channels/Details")]
        public IHttpResponse Details(int id)
        {
            //IsUserAny();
            if (this.User == null)
            {
                return Redirect("/Users/Login");
            }

            var chanellViewModel = this.Db.Channels.Where(x => x.Id == id)
                .Select(x => new BaseChannelViewModels
                {
                    Id = x.Id,
                    Type = x.ChannelType,
                    Name = x.Name,
                    Description = x.Description,
                    Tags = x.Tags.Select(t => t.Tag.Name),
                    FollowersCount = x.Followers.Count
                }).FirstOrDefault();

            return this.View(chanellViewModel);
        }

        [HttpGet(Url = ("/Channels/Follow"))]
        public IHttpResponse Follow(int id)
        {

            var user = this.Db.Users.FirstOrDefault(x => x.Username == this.User.Username);

            if (user == null)
            {
                return this.Redirect("/Users/Login");
            }

            if (!this.Db.UserInChannels.Any(x => x.UserId == user.Id && x.ChannelId == id))
            {
                this.Db.UserInChannels.Add(new UserInChannel()
                {
                    ChannelId = id,
                    UserId = user.Id
                });
                this.Db.SaveChanges();

            }

            return this.Redirect("/Channel/Followed");



        }

        [HttpGet(Url = ("/Channels/Unfollow"))]
        public IHttpResponse UnFollow(int id)
        {

            var user = this.Db.Users.FirstOrDefault(x => x.Username == this.User.Username);

            if (user == null)
            {
                return this.Redirect("/Users/Login");
            }

            var userInChanel = this.Db.UserInChannels.FirstOrDefault(
                x => x.UserId == user.Id && x.ChannelId == id);

            if (userInChanel!=null)
            {
                this.Db.UserInChannels.Remove(userInChanel);
                this.Db.SaveChanges();
            }

            return this.Redirect("/Channel/UnFollowed");



        }

        [HttpGet(Url = "/Channels/Followed")]
        public IHttpResponse Followed()
        {
            //IsUserAny();
            if (this.User == null)
            {
                return Redirect("/Users/Login");
            }

            //todo channels are null add records
            //var usersAny = Db.Channels.Where(x => x.Followers.Any()).ToList();
            var followedChannels = this.Db.Channels.Where(x => x.Followers.Any(f => f.User.Username == this.User.Username))
                 .Select(t => new FollowedChannelViewModel()
                 {
                     Id = t.Id,
                     Name = t.Name,
                     Type = t.ChannelType,
                     FollowersCount = t.Followers.Count

                 }).ToList();

            var followedChanelsViewModel = new FollowedChannelsViewModel()
            {
                FollowedChannels = followedChannels
            };
            return this.View(followedChanelsViewModel);
        }

        private void IsUserAny()
        {
            if (this.User == null)
            {
                this.Redirect("/Users/Login");
            }

        }
    }
}