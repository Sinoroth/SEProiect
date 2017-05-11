﻿using MVC.Models;
using Newtonsoft.Json;
using Plugin.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class ContractsController : Controller
    {
        // GET: Contracts
        public List<Contract> GetContracts()
        {
            RestClient<Contract> rc = new RestClient<Contract>();
            rc.WebServiceUrl = "http://localhost:55428/api/contracts/";
            var contractList =  rc.GetAsync();
            return contractList;
        }

        public Contract GetContractById(int id)
        {
            RestClient<Contract> rc = new RestClient<Contract>();
            rc.WebServiceUrl = "http://localhost:55428/api/contracts/";
            var contract = rc.GetByIdAsync(id);
            return contract;
        }

        public bool PostContract(Contract c)
        {
            RestClient<Contract> rc = new RestClient<Contract>();
            rc.WebServiceUrl = "http://localhost:55428/api/contracts/";
            bool response = rc.PostAsync(c);
            return response;
        }

        public bool PutContract(int id, Contract c)
        {
            RestClient<Contract> rc = new RestClient<Contract>();
            rc.WebServiceUrl = "http://localhost:55428/api/contracts/";
            bool response = rc.PutAsync(id, c);
            return response;
        }

        public bool DeleteContract(int id, Contract c)
        {
            RestClient<Contract> rc = new RestClient<Contract>();
            rc.WebServiceUrl = "http://localhost:55428/api/contracts/";
            bool response = rc.DeleteAsync(id, c);
            return response;
        }


        public ActionResult List()
        {

            //Contract contract = new Contract();
            //contract.ContractId = 1;
            //contract.ContractPeriod = "10.05.2016 - 10.05.2017";
            //contract.Cost = 2000;
            //contract.Supplier = "Digi";
            //contract.ServicesFacilitiesOffered = "TV";
            //List<Contract> contractList = new List<Contract>();
            //contractList.Add(contract);
            List<Contract> contractList = GetContracts();

            return View(contractList);
        }

        public ActionResult Create()
        {

            //PostAsync();
            return View();
        }

        public ActionResult Edit()
        {
            //PutAsync();
            return View();
        }

        public ActionResult Details()
        {
            //GetByIdAsync();
            Contract contract = new Contract();
            contract.ContractId = 1;
            contract.ContractPeriod = "10.05.2016 - 10.05.2017";
            contract.Cost = 2000;
            contract.Supplier = "Digi";
            contract.ServicesFacilitiesOffered = "TV";
            //List<Contract> contractList = new List<Contract>();
            //contractList.Add(contract);

            return View(contract);
        }

        public ActionResult Delete()
        {
            //DeleteAsync();
            return View();
        }
    }
}