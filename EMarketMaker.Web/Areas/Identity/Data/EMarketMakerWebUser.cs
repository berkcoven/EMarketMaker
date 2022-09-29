using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMarketMaker.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace EMarketMaker.Web.Areas.Identity.Data;

// Add profile data for application users by adding properties to the EMarketMakerWebUser class
public class EMarketMakerWebUser : IdentityUser
{
    public AppUser appUser{ get; set; }
}

