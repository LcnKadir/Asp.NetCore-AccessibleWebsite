using CoreLayer.Models;
using CoreLayer.Services;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services;

namespace AccessibleWebsite.ViewComponents.Admin
{
    public class _GetUserClassRegister : ViewComponent
    {
        private readonly IMessageService _messageService;
        private readonly IAppUserService _appUserService;

        public _GetUserClassRegister(IMessageService messageService, IAppUserService appUserService)
        {
            _messageService = messageService;
            _appUserService = appUserService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int userId)
        {
          
            var user = await _appUserService.GetByIdAsync(userId);
            var clases = await _messageService.GetwasPickClass(user.Id);

            return View(clases);
        }
    }
}
