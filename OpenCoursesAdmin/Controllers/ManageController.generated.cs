// <auto-generated />
// This file was generated by R4Mvc.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the r4mvc.json file (i.e. the settings file), save it and run the generator tool again.

// Make sure the compiler doesn't complain about missing Xml comments and CLS compliance
// 0108: suppress "Foo hides inherited member Foo.Use the new keyword if hiding was intended." when a controller and its abstract parent are both processed
#pragma warning disable 1591, 3008, 3009, 0108
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using R4Mvc;

namespace OpenCoursesAdmin.Controllers
{
    public partial class ManageController
    {
        [GeneratedCode("R4Mvc", "1.0"), DebuggerNonUserCode]
        protected ManageController(Dummy d)
        {
        }

        [GeneratedCode("R4Mvc", "1.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(IActionResult result)
        {
            var callInfo = result.GetR4MvcResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("R4Mvc", "1.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(Task<IActionResult> taskResult)
        {
            return RedirectToAction(taskResult.Result);
        }

        [GeneratedCode("R4Mvc", "1.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(IActionResult result)
        {
            var callInfo = result.GetR4MvcResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("R4Mvc", "1.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(Task<IActionResult> taskResult)
        {
            return RedirectToActionPermanent(taskResult.Result);
        }

        [NonAction]
        [GeneratedCode("R4Mvc", "1.0"), DebuggerNonUserCode]
        public virtual IActionResult SendVerificationEmail()
        {
            return new R4Mvc_Microsoft_AspNetCore_Mvc_ActionResult(Area, Name, ActionNames.SendVerificationEmail);
        }

        [NonAction]
        [GeneratedCode("R4Mvc", "1.0"), DebuggerNonUserCode]
        public virtual IActionResult LinkLogin()
        {
            return new R4Mvc_Microsoft_AspNetCore_Mvc_ActionResult(Area, Name, ActionNames.LinkLogin);
        }

        [NonAction]
        [GeneratedCode("R4Mvc", "1.0"), DebuggerNonUserCode]
        public virtual IActionResult RemoveLogin()
        {
            return new R4Mvc_Microsoft_AspNetCore_Mvc_ActionResult(Area, Name, ActionNames.RemoveLogin);
        }

        [GeneratedCode("R4Mvc", "1.0"), DebuggerNonUserCode]
        public ManageController Actions => MVC.Manage;
        [GeneratedCode("R4Mvc", "1.0")]
        public readonly string Area = "";
        [GeneratedCode("R4Mvc", "1.0")]
        public readonly string Name = "Manage";
        [GeneratedCode("R4Mvc", "1.0")]
        public const string NameConst = "Manage";
        [GeneratedCode("R4Mvc", "1.0")]
        static readonly ActionNamesClass s_ActionNames = new ActionNamesClass();
        [GeneratedCode("R4Mvc", "1.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames => s_ActionNames;
        [GeneratedCode("R4Mvc", "1.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Index = "Index";
            public readonly string SendVerificationEmail = "SendVerificationEmail";
            public readonly string ChangePassword = "ChangePassword";
            public readonly string SetPassword = "SetPassword";
            public readonly string ExternalLogins = "ExternalLogins";
            public readonly string LinkLogin = "LinkLogin";
            public readonly string LinkLoginCallback = "LinkLoginCallback";
            public readonly string RemoveLogin = "RemoveLogin";
            public readonly string TwoFactorAuthentication = "TwoFactorAuthentication";
            public readonly string Disable2faWarning = "Disable2faWarning";
            public readonly string Disable2fa = "Disable2fa";
            public readonly string EnableAuthenticator = "EnableAuthenticator";
            public readonly string ResetAuthenticatorWarning = "ResetAuthenticatorWarning";
            public readonly string ResetAuthenticator = "ResetAuthenticator";
            public readonly string GenerateRecoveryCodes = "GenerateRecoveryCodes";
        }

        [GeneratedCode("R4Mvc", "1.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Index = "Index";
            public const string SendVerificationEmail = "SendVerificationEmail";
            public const string ChangePassword = "ChangePassword";
            public const string SetPassword = "SetPassword";
            public const string ExternalLogins = "ExternalLogins";
            public const string LinkLogin = "LinkLogin";
            public const string LinkLoginCallback = "LinkLoginCallback";
            public const string RemoveLogin = "RemoveLogin";
            public const string TwoFactorAuthentication = "TwoFactorAuthentication";
            public const string Disable2faWarning = "Disable2faWarning";
            public const string Disable2fa = "Disable2fa";
            public const string EnableAuthenticator = "EnableAuthenticator";
            public const string ResetAuthenticatorWarning = "ResetAuthenticatorWarning";
            public const string ResetAuthenticator = "ResetAuthenticator";
            public const string GenerateRecoveryCodes = "GenerateRecoveryCodes";
        }

        [GeneratedCode("R4Mvc", "1.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames => s_ViewNames;
            public class _ViewNamesClass
            {
                public readonly string ChangePassword = "ChangePassword";
                public readonly string Disable2fa = "Disable2fa";
                public readonly string EnableAuthenticator = "EnableAuthenticator";
                public readonly string ExternalLogins = "ExternalLogins";
                public readonly string GenerateRecoveryCodes = "GenerateRecoveryCodes";
                public readonly string Index = "Index";
                public readonly string ResetAuthenticator = "ResetAuthenticator";
                public readonly string SetPassword = "SetPassword";
                public readonly string TwoFactorAuthentication = "TwoFactorAuthentication";
                public readonly string _Layout = "_Layout";
                public readonly string _ManageNav = "_ManageNav";
                public readonly string _StatusMessage = "_StatusMessage";
                public readonly string _ViewImports = "_ViewImports";
            }

            public readonly string ChangePassword = "~/Views/Manage/ChangePassword.cshtml";
            public readonly string Disable2fa = "~/Views/Manage/Disable2fa.cshtml";
            public readonly string EnableAuthenticator = "~/Views/Manage/EnableAuthenticator.cshtml";
            public readonly string ExternalLogins = "~/Views/Manage/ExternalLogins.cshtml";
            public readonly string GenerateRecoveryCodes = "~/Views/Manage/GenerateRecoveryCodes.cshtml";
            public readonly string Index = "~/Views/Manage/Index.cshtml";
            public readonly string ResetAuthenticator = "~/Views/Manage/ResetAuthenticator.cshtml";
            public readonly string SetPassword = "~/Views/Manage/SetPassword.cshtml";
            public readonly string TwoFactorAuthentication = "~/Views/Manage/TwoFactorAuthentication.cshtml";
            public readonly string _Layout = "~/Views/Manage/_Layout.cshtml";
            public readonly string _ManageNav = "~/Views/Manage/_ManageNav.cshtml";
            public readonly string _StatusMessage = "~/Views/Manage/_StatusMessage.cshtml";
            public readonly string _ViewImports = "~/Views/Manage/_ViewImports.cshtml";
        }

        [GeneratedCode("R4Mvc", "1.0")]
        static readonly ViewsClass s_Views = new ViewsClass();
        [GeneratedCode("R4Mvc", "1.0"), DebuggerNonUserCode]
        public ViewsClass Views => s_Views;
    }

    [GeneratedCode("R4Mvc", "1.0"), DebuggerNonUserCode]
    public partial class R4MVC_ManageController : OpenCoursesAdmin.Controllers.ManageController
    {
        public R4MVC_ManageController(): base(Dummy.Instance)
        {
        }

        [NonAction]
        partial void IndexOverride(R4Mvc_Microsoft_AspNetCore_Mvc_ActionResult callInfo);
        [NonAction]
        public override System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> Index()
        {
            var callInfo = new R4Mvc_Microsoft_AspNetCore_Mvc_ActionResult(Area, Name, ActionNames.Index);
            IndexOverride(callInfo);
            return System.Threading.Tasks.Task.FromResult(callInfo as Microsoft.AspNetCore.Mvc.IActionResult);
        }

        [NonAction]
        partial void IndexOverride(R4Mvc_Microsoft_AspNetCore_Mvc_ActionResult callInfo, OpenCoursesAdmin.Models.ManageViewModels.IndexViewModel model);
        [NonAction]
        public override System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> Index(OpenCoursesAdmin.Models.ManageViewModels.IndexViewModel model)
        {
            var callInfo = new R4Mvc_Microsoft_AspNetCore_Mvc_ActionResult(Area, Name, ActionNames.Index);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            IndexOverride(callInfo, model);
            return System.Threading.Tasks.Task.FromResult(callInfo as Microsoft.AspNetCore.Mvc.IActionResult);
        }

        [NonAction]
        partial void SendVerificationEmailOverride(R4Mvc_Microsoft_AspNetCore_Mvc_ActionResult callInfo, OpenCoursesAdmin.Models.ManageViewModels.IndexViewModel model);
        [NonAction]
        public override System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> SendVerificationEmail(OpenCoursesAdmin.Models.ManageViewModels.IndexViewModel model)
        {
            var callInfo = new R4Mvc_Microsoft_AspNetCore_Mvc_ActionResult(Area, Name, ActionNames.SendVerificationEmail);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            SendVerificationEmailOverride(callInfo, model);
            return System.Threading.Tasks.Task.FromResult(callInfo as Microsoft.AspNetCore.Mvc.IActionResult);
        }

        [NonAction]
        partial void ChangePasswordOverride(R4Mvc_Microsoft_AspNetCore_Mvc_ActionResult callInfo);
        [NonAction]
        public override System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> ChangePassword()
        {
            var callInfo = new R4Mvc_Microsoft_AspNetCore_Mvc_ActionResult(Area, Name, ActionNames.ChangePassword);
            ChangePasswordOverride(callInfo);
            return System.Threading.Tasks.Task.FromResult(callInfo as Microsoft.AspNetCore.Mvc.IActionResult);
        }

        [NonAction]
        partial void ChangePasswordOverride(R4Mvc_Microsoft_AspNetCore_Mvc_ActionResult callInfo, OpenCoursesAdmin.Models.ManageViewModels.ChangePasswordViewModel model);
        [NonAction]
        public override System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> ChangePassword(OpenCoursesAdmin.Models.ManageViewModels.ChangePasswordViewModel model)
        {
            var callInfo = new R4Mvc_Microsoft_AspNetCore_Mvc_ActionResult(Area, Name, ActionNames.ChangePassword);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            ChangePasswordOverride(callInfo, model);
            return System.Threading.Tasks.Task.FromResult(callInfo as Microsoft.AspNetCore.Mvc.IActionResult);
        }

        [NonAction]
        partial void SetPasswordOverride(R4Mvc_Microsoft_AspNetCore_Mvc_ActionResult callInfo);
        [NonAction]
        public override System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> SetPassword()
        {
            var callInfo = new R4Mvc_Microsoft_AspNetCore_Mvc_ActionResult(Area, Name, ActionNames.SetPassword);
            SetPasswordOverride(callInfo);
            return System.Threading.Tasks.Task.FromResult(callInfo as Microsoft.AspNetCore.Mvc.IActionResult);
        }

        [NonAction]
        partial void SetPasswordOverride(R4Mvc_Microsoft_AspNetCore_Mvc_ActionResult callInfo, OpenCoursesAdmin.Models.ManageViewModels.SetPasswordViewModel model);
        [NonAction]
        public override System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> SetPassword(OpenCoursesAdmin.Models.ManageViewModels.SetPasswordViewModel model)
        {
            var callInfo = new R4Mvc_Microsoft_AspNetCore_Mvc_ActionResult(Area, Name, ActionNames.SetPassword);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            SetPasswordOverride(callInfo, model);
            return System.Threading.Tasks.Task.FromResult(callInfo as Microsoft.AspNetCore.Mvc.IActionResult);
        }

        [NonAction]
        partial void ExternalLoginsOverride(R4Mvc_Microsoft_AspNetCore_Mvc_ActionResult callInfo);
        [NonAction]
        public override System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> ExternalLogins()
        {
            var callInfo = new R4Mvc_Microsoft_AspNetCore_Mvc_ActionResult(Area, Name, ActionNames.ExternalLogins);
            ExternalLoginsOverride(callInfo);
            return System.Threading.Tasks.Task.FromResult(callInfo as Microsoft.AspNetCore.Mvc.IActionResult);
        }

        [NonAction]
        partial void LinkLoginOverride(R4Mvc_Microsoft_AspNetCore_Mvc_ActionResult callInfo, string provider);
        [NonAction]
        public override System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> LinkLogin(string provider)
        {
            var callInfo = new R4Mvc_Microsoft_AspNetCore_Mvc_ActionResult(Area, Name, ActionNames.LinkLogin);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "provider", provider);
            LinkLoginOverride(callInfo, provider);
            return System.Threading.Tasks.Task.FromResult(callInfo as Microsoft.AspNetCore.Mvc.IActionResult);
        }

        [NonAction]
        partial void LinkLoginCallbackOverride(R4Mvc_Microsoft_AspNetCore_Mvc_ActionResult callInfo);
        [NonAction]
        public override System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> LinkLoginCallback()
        {
            var callInfo = new R4Mvc_Microsoft_AspNetCore_Mvc_ActionResult(Area, Name, ActionNames.LinkLoginCallback);
            LinkLoginCallbackOverride(callInfo);
            return System.Threading.Tasks.Task.FromResult(callInfo as Microsoft.AspNetCore.Mvc.IActionResult);
        }

        [NonAction]
        partial void RemoveLoginOverride(R4Mvc_Microsoft_AspNetCore_Mvc_ActionResult callInfo, OpenCoursesAdmin.Models.ManageViewModels.RemoveLoginViewModel model);
        [NonAction]
        public override System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> RemoveLogin(OpenCoursesAdmin.Models.ManageViewModels.RemoveLoginViewModel model)
        {
            var callInfo = new R4Mvc_Microsoft_AspNetCore_Mvc_ActionResult(Area, Name, ActionNames.RemoveLogin);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            RemoveLoginOverride(callInfo, model);
            return System.Threading.Tasks.Task.FromResult(callInfo as Microsoft.AspNetCore.Mvc.IActionResult);
        }

        [NonAction]
        partial void TwoFactorAuthenticationOverride(R4Mvc_Microsoft_AspNetCore_Mvc_ActionResult callInfo);
        [NonAction]
        public override System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> TwoFactorAuthentication()
        {
            var callInfo = new R4Mvc_Microsoft_AspNetCore_Mvc_ActionResult(Area, Name, ActionNames.TwoFactorAuthentication);
            TwoFactorAuthenticationOverride(callInfo);
            return System.Threading.Tasks.Task.FromResult(callInfo as Microsoft.AspNetCore.Mvc.IActionResult);
        }

        [NonAction]
        partial void Disable2faWarningOverride(R4Mvc_Microsoft_AspNetCore_Mvc_ActionResult callInfo);
        [NonAction]
        public override System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> Disable2faWarning()
        {
            var callInfo = new R4Mvc_Microsoft_AspNetCore_Mvc_ActionResult(Area, Name, ActionNames.Disable2faWarning);
            Disable2faWarningOverride(callInfo);
            return System.Threading.Tasks.Task.FromResult(callInfo as Microsoft.AspNetCore.Mvc.IActionResult);
        }

        [NonAction]
        partial void Disable2faOverride(R4Mvc_Microsoft_AspNetCore_Mvc_ActionResult callInfo);
        [NonAction]
        public override System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> Disable2fa()
        {
            var callInfo = new R4Mvc_Microsoft_AspNetCore_Mvc_ActionResult(Area, Name, ActionNames.Disable2fa);
            Disable2faOverride(callInfo);
            return System.Threading.Tasks.Task.FromResult(callInfo as Microsoft.AspNetCore.Mvc.IActionResult);
        }

        [NonAction]
        partial void EnableAuthenticatorOverride(R4Mvc_Microsoft_AspNetCore_Mvc_ActionResult callInfo);
        [NonAction]
        public override System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> EnableAuthenticator()
        {
            var callInfo = new R4Mvc_Microsoft_AspNetCore_Mvc_ActionResult(Area, Name, ActionNames.EnableAuthenticator);
            EnableAuthenticatorOverride(callInfo);
            return System.Threading.Tasks.Task.FromResult(callInfo as Microsoft.AspNetCore.Mvc.IActionResult);
        }

        [NonAction]
        partial void EnableAuthenticatorOverride(R4Mvc_Microsoft_AspNetCore_Mvc_ActionResult callInfo, OpenCoursesAdmin.Models.ManageViewModels.EnableAuthenticatorViewModel model);
        [NonAction]
        public override System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> EnableAuthenticator(OpenCoursesAdmin.Models.ManageViewModels.EnableAuthenticatorViewModel model)
        {
            var callInfo = new R4Mvc_Microsoft_AspNetCore_Mvc_ActionResult(Area, Name, ActionNames.EnableAuthenticator);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            EnableAuthenticatorOverride(callInfo, model);
            return System.Threading.Tasks.Task.FromResult(callInfo as Microsoft.AspNetCore.Mvc.IActionResult);
        }

        [NonAction]
        partial void ResetAuthenticatorWarningOverride(R4Mvc_Microsoft_AspNetCore_Mvc_ActionResult callInfo);
        [NonAction]
        public override Microsoft.AspNetCore.Mvc.IActionResult ResetAuthenticatorWarning()
        {
            var callInfo = new R4Mvc_Microsoft_AspNetCore_Mvc_ActionResult(Area, Name, ActionNames.ResetAuthenticatorWarning);
            ResetAuthenticatorWarningOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void ResetAuthenticatorOverride(R4Mvc_Microsoft_AspNetCore_Mvc_ActionResult callInfo);
        [NonAction]
        public override System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> ResetAuthenticator()
        {
            var callInfo = new R4Mvc_Microsoft_AspNetCore_Mvc_ActionResult(Area, Name, ActionNames.ResetAuthenticator);
            ResetAuthenticatorOverride(callInfo);
            return System.Threading.Tasks.Task.FromResult(callInfo as Microsoft.AspNetCore.Mvc.IActionResult);
        }

        [NonAction]
        partial void GenerateRecoveryCodesOverride(R4Mvc_Microsoft_AspNetCore_Mvc_ActionResult callInfo);
        [NonAction]
        public override System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GenerateRecoveryCodes()
        {
            var callInfo = new R4Mvc_Microsoft_AspNetCore_Mvc_ActionResult(Area, Name, ActionNames.GenerateRecoveryCodes);
            GenerateRecoveryCodesOverride(callInfo);
            return System.Threading.Tasks.Task.FromResult(callInfo as Microsoft.AspNetCore.Mvc.IActionResult);
        }
    }
}
#pragma warning restore 1591, 3008, 3009, 0108
