using System.Collections.Generic;
using System.Linq;
using MishMashWebApp.ViewModels.Channels;
using MishMashWebApp.ViewModels.Home;
using SIS.HTTP.Responses;
using SIS.MvcFramework.Attributes;

namespace MishMashWebApp.Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet]
        public IHttpResponse Index()
        {
            if (this.User != null)
            {
                var viewModel = new LoggedInIndexViewModel();
                viewModel.UserRole = this.User.Roles.ToString();
                viewModel.YouChannels = this.Db.Channels.Where(x => x.Followers.Any(f => f.User.Username == this.User.Username))
                    .Select(t => new BaseChannelViewModels()
                    {
                        Id = t.Id,
                        Name = t.Name,
                        Type = t.ChannelType,
                        FollowersCount = t.Followers.Count()

                    }).ToList();

                var followedChanelsTags = Db.Channels
                    .Where(x => x.Followers.Any(f => f.User.Username == this.User.Username))
                    .SelectMany(x => x.Tags.Select(t => t.Id)).ToList();

                var suggestedChannels = this.Db.Channels.Where(
                    x => x.Followers.All(f => f.User.Username != this.User.Username) &&
                         x.Tags.Any(t => followedChanelsTags.Contains(t.Id)))
                    .Select(t => new BaseChannelViewModels()
                    {
                        Id = t.Id,
                        Name = t.Name,
                        Type = t.ChannelType,
                        FollowersCount = t.Followers.Count()

                    }).ToList(); 

                var ids = viewModel.YouChannels.Select(x => x.Id).ToList();
                ids = ids.Concat(viewModel.SuggestedChannels.Select(x => x.Id).ToList()) as List<int>;
                ids = ids.Distinct().ToList();

                viewModel.SeeOtherChannels = this.Db.Channels.Where(x => !ids.Contains(x.Id))
                    .Select(t => new BaseChannelViewModels()
                {
                    Id = t.Id,
                    Name = t.Name,
                    Type = t.ChannelType,
                    FollowersCount = t.Followers.Count()
                }).ToList();
                return this.View(viewModel,"LoggedInIndex");
            }
            return this.View();
        }

        [HttpGet(Url = "/")]
        public IHttpResponse RootIndex()
        {
            return this.Index();
        }

    }
}