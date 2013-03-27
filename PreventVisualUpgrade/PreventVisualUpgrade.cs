using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;

namespace BeenJammin.SharePoint.PreventVisualUpgrade
{
    /// <summary>
    /// Web Events
    /// </summary>
    public class PreventVisualUpgrade : SPWebEventReceiver
    {
       /// <summary>
       /// A site was provisioned.
       /// </summary>
       public override void WebProvisioned(SPWebEventProperties properties)
       {
           base.WebProvisioned(properties);
           using (SPWeb oWeb = properties.Web)
           {
               string parentMaster = oWeb.ParentWeb.MasterUrl;
               string parentCustom = oWeb.ParentWeb.CustomMasterUrl;
               oWeb.Site.AllowUnsafeUpdates = true;
               oWeb.AllowUnsafeUpdates = true;
               oWeb.UIVersionConfigurationEnabled = true;
               oWeb.UIVersion = 3;
               oWeb.CustomMasterUrl = parentCustom;
               oWeb.MasterUrl = parentMaster;
               oWeb.AllProperties["__InheritsCustomMasterUrl"] = "True";
               oWeb.AllProperties["__InheritsMasterUrl"] = "True";
               oWeb.Update();
               oWeb.AllowUnsafeUpdates = false;
               oWeb.Site.AllowUnsafeUpdates = false;
           }
       }


    }
}
