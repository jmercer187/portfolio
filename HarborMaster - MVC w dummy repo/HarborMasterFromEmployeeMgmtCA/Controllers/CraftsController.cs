using HarborMasterFromEmployeeMgmtCA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HarborMasterFromEmployeeMgmtCA.Controllers
{
    public class CraftsController : Controller
    {
        [HttpGet]
        public ActionResult List()
        {
            List<CraftListViewModel> model = (from craft in CraftRepo.GetAll()
                                              join craftType in CraftTypeRepo.GetAll() on craft.CraftTypeID equals craftType.CraftTypeID
                                              join membership in MembershipRepo.GetAll() on craft.MembershipID equals membership.MembershipID
                                              select new CraftListViewModel()
                                              {
                                                  Owner = craft.OwnerFirstName + " " + craft.OwnerLastName,
                                                  MembershipType = membership.MembershipType,
                                                  DockNumber = craft.DockNumber,
                                                  NameOfCraft = craft.NameOfCraft,
                                                  TypeOfCraft = craftType.TypeOfCraft,
                                                  LOA = craft.LOA,
                                                  OwnerID = craft.OwnerID,

                                              }).ToList();
                
            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            AddCraftViewModel model = new AddCraftViewModel();

            model.CraftTypes = GetCraftTypeSelectList();

            model.MembershipTypes = GetMembershipSelectList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(AddCraftViewModel model)
        {
            Craft craft = new Craft();

            if(ModelState.IsValid)
            {
                craft.OwnerFirstName = model.OwnerFirstName;
                craft.OwnerLastName = model.OwnerLastName;
                craft.NameOfCraft = model.NameOfCraft;
                craft.DockNumber = model.DockNumber;
                craft.LOA = model.LOA;
                craft.MembershipID = model.MembershipID;
                craft.CraftTypeID = model.CrafTypeID;

                CraftRepo.Add(craft);

                return RedirectToAction("List");
            }
            else
            {
                model.CraftTypes = GetCraftTypeSelectList();

                model.MembershipTypes = GetMembershipSelectList();

                return View(model);
            }
            
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var craft = CraftRepo.GetCraft(id);

            var model = new EditCraftViewModel();
            model.OwnerFirstName = craft.OwnerFirstName;
            model.OwnerLastName = craft.OwnerLastName;
            model.OwnerID = craft.OwnerID;
            model.DockNumber = craft.DockNumber;
            model.LOA = craft.LOA;
            model.NameOfCraft = craft.NameOfCraft;
            model.MembershipID = craft.MembershipID;
            model.CrafTypeID = craft.CraftTypeID;

            model.MembershipTypes = GetMembershipSelectList();
            model.CraftTypes = GetCraftTypeSelectList();

            return View(model);

        }

        [HttpPost]
        public ActionResult Edit(EditCraftViewModel model)
        {
            Craft craft = new Craft();

            if (ModelState.IsValid)
            {
                craft.OwnerID = model.OwnerID;
                craft.OwnerFirstName = model.OwnerFirstName;
                craft.OwnerLastName = model.OwnerLastName;
                craft.NameOfCraft = model.NameOfCraft;
                craft.DockNumber = model.DockNumber;
                craft.LOA = model.LOA;
                craft.MembershipID = model.MembershipID;
                craft.CraftTypeID = model.CrafTypeID;

                CraftRepo.Edit(craft);

                return RedirectToAction("List");
            }
            else
            {
                model.CraftTypes = GetCraftTypeSelectList();

                model.MembershipTypes = GetMembershipSelectList();

                return View(model);
            }
        }

        private List<SelectListItem> GetCraftTypeSelectList()
        {
            return (from craftType in CraftTypeRepo.GetAll()
                    select new SelectListItem()
                    {
                        Text = craftType.TypeOfCraft,
                        Value = craftType.CraftTypeID.ToString(),
                    }).ToList();
        }

        private List<SelectListItem> GetMembershipSelectList()
        {
            return (from membership in MembershipRepo.GetAll()
                    select new SelectListItem()
                    {
                        Text = membership.MembershipType,
                        Value = membership.MembershipID.ToString(),
                    }).ToList();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            CraftRepo.Delete(id);
            return RedirectToAction("List");
                
        }
    }

}