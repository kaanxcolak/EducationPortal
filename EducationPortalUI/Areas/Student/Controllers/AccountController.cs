﻿using AutoMapper;
using EducationPortalBL.InterfacesOfManagers;
using EducationPortalEL.Constants;
using EducationPortalEL.IdentityModels;
using EducationPortalEL.Models;
using EducationPortalEL.ViewModels;
using EducationPortalUI.DefaultData;
using EducationPortalUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace EducationPortalUI.Areas.Student.Controllers;

[Area("Student")]
[Route("Account/[Action]/{id?}")]
public class AccountController : Controller
{
	private readonly UserManager<AppUser> _userManager;
	private readonly RoleManager<AppRole> _roleManager;
	private readonly SignInManager<AppUser> _signInManager;
	private readonly IEducationInfoManager _educationInfoManager;
	private readonly IMapper _mapper;

	const int keySize = 64;
	const int iterations = 350000;
	//HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

	public AccountController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager, IEducationInfoManager educationInfoManager, IMapper mapper)
	{
		_userManager = userManager;
		_roleManager = roleManager;
		_signInManager = signInManager;
		_educationInfoManager = educationInfoManager;
		_mapper = mapper;
	}
	public IActionResult Dashboard()
	{
		return View();
	}

	[HttpGet]
	public IActionResult Login()
	{
		return View();
	}

	[HttpPost]
	public IActionResult Login(LoginViewModel model)
	{
		try
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var user = _userManager.FindByEmailAsync(model.UserNameOrEmail).Result;

			if (user == null)
			{
				ModelState.AddModelError("", "Email ya da şifre hatalidir!");
				return View(model);
			}
			var signinResult =
			 _signInManager.PasswordSignInAsync(user, model.Password, true, true).Result;
			TempData["LoggedInUsername"] = user.UserName; //username sayisal deger olarak geliyor!
			TempData["LoggedInNameSurname"] = $"{user.Name} {user.Surname}";

			if (!signinResult.Succeeded)
			{
				ModelState.AddModelError("", "Giris BASARISIZDIR!");
				return View(model);
			}
			if (_userManager.IsInRoleAsync(user, ConstantDatas.STUDENTROLE).Result)
			{
				var claims = new List<Claim>()
				{
				   new Claim(ClaimTypes.Name, user.UserName,null,null,null,new ClaimsIdentity(AuthenticationSchemes.StudentArea))
				};

				//var identity = new ClaimsIdentity(claims, AuthenticationSchemes.BranchArea);
				var r = _userManager.AddClaimsAsync(user, claims).Result;
				return RedirectToAction("Index", "Account", new { area = "Student" });
			}
			else if (_userManager.IsInRoleAsync(user, "Account").Result)
			{


				return RedirectToAction("Dashboard", "Account", new { area = "" });
			}
			else
			{
				return RedirectToAction("Index", "Account");
			}
			return View();
		}
		catch (Exception ex)
		{
			ModelState.AddModelError("", "Beklenmedik bir hata olustu!");
			return View(model);
		}
	}

	public IActionResult Index()
	{

		return View();
	}

	[HttpGet]
	public IActionResult EducationInfo()
	{
		return View();
	}

	
	[HttpPost]
	public IActionResult EducationInfo(EducationInfoVM model)
	{
		try
		{
			if (!ModelState.IsValid)
			{
				ModelState.AddModelError("", "Bilgileri düzgün giriniz");
				return View(model);
			}

			var sameEducationInfo = _educationInfoManager.GetByConditions(x => x.CategoryId == model.CategoryId && x.CreatedDate == model.CreatedDate).Data;


			if (sameEducationInfo != null)
			{
				ModelState.AddModelError("", "Eğitim tanımlanması var!");
				return View(model);
			}

			// eğitim tanımlanmış mı?
			//yoksa ekle
			var education = _userManager.FindByEmailAsync(model.Trainer.Email).Result;

			if (education == null)
			{
				AppUser user = new AppUser()
				{
					UserName = model.Trainer.TcNo,
					Name = model.Trainer.Name,
					Surname = model.Trainer.Surname,
					TcNo = model.Trainer.TcNo,
					PhoneNumber = model.Trainer.Phone,
					Email = model.Trainer.Email,
					EmailConfirmed = true,
				};

				var result = _userManager.CreateAsync(user, model.Trainer.TcNo).Result;
				if (result.Succeeded)
				{
					var roleResult = _userManager.AddToRoleAsync(user, "Trainer").Result;
				}
			}
			EducationInfoVM educationInfo = new EducationInfoVM()
			{
				TrainerTypeId = model.TrainerTypeId, // giriş yapan trainer
				Name = model.Name,
				Kontenjan = model.Kontenjan,
				Time = model.Time,
				PricePerDay = model.PricePerDay,
				CreatedDate = model.CreatedDate,
				IsRemoved = model.IsRemoved,

			};

			if (_educationInfoManager.Add(_mapper.Map<EducationInfoVM>(educationInfo)).IsSuccess)
			{
				TempData["AppointmentSuccessMsg"] = "Kayıt başarılı!";
				return RedirectToAction("EducationInfo", "admin");

			}
			else
			{
				ModelState.AddModelError("", "Eğitim oluştu! Ancak rolü atanamadı! Sistem yöneticisine ulaşarak rol ataması yapılmalıdır!");
				return View(model);

			}
		}

		catch (Exception ex)
		{
			return View(model);
		}

	}




	[HttpGet]
	public IActionResult Register()
	{

		return View();
	}

	[HttpPost]
	public IActionResult Register(RegisterViewModel model)
	{
		try
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			// aynı username'den varsa hata versin
			var sameUser = _userManager.FindByNameAsync(model.Username).Result; // async bir metodun sonuna .Result yazarsak metod senkron çalışır
			if (sameUser != null)
			{
				ModelState.AddModelError("", "Bu kullanıcı ismi sistemde mevcuttur! Farklı kullanıcı adı deneyiniz!");
			}


			sameUser = _userManager.FindByEmailAsync(model.Email).Result;
			if (sameUser != null)
			{
				ModelState.AddModelError("", "Bu email ile sistemde mevcuttur! Farklı email deneyiniz!");
			}


			AppUser user = new AppUser()
			{
				UserName = model.Username,
				Name = model.Name,
				Surname = model.Surname,
				TcNo = model.TcNo,
				PhoneNumber = model.PhoneNumber,
				Email = model.Email,
				EmailConfirmed = true,
			};

			var result = _userManager.CreateAsync(user, model.Password).Result;
			if (result.Succeeded)
			{

				var roleResult = _userManager.AddToRoleAsync(user, ConstantDatas.STUDENTROLE).Result;

				if (roleResult.Succeeded)
				{
					TempData["RegisterSuccessMsg"] = "Kayıt başarılı!";
				}
				else
				{
					TempData["RegisterWarningMsg"] = "Kullanıcı oluştu! Ancak rolü atanamadı! Sistem yöneticisine ulaşarak rol ataması yapılmalıdır!";
				}
				return RedirectToAction("Login", "Account");
			}
			else
			{
				ModelState.AddModelError("", "Ekleme başarısız!");
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError("", item.Description);

				}
				return View(model);
			}
		}
		catch (Exception ex)
		{
			ModelState.AddModelError("", "Beklenmedik hata oluştu!");
			return View(model);

		}
	}



	//public IActionResult NewEducationAdd()
	//{
	//    try
	//    {

	//    }
	//    catch (Exception ex)
	//    {
	//        ViewBag.
	//    }
	//}

}