using AutoMapper;
using MembershipApi.Data;
using MembershipApi.Dtos;
using MembershipApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;

namespace MembershipApi.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class PaymentController : Controller
    {
        private readonly IPaymentRepo _paymentRepo;
        private readonly IMapper _mapper;
        private readonly IItemTypes _items;
        private readonly IOrder _orderHelper;

        public PaymentController(IPaymentRepo paymentRepo, IMapper mapper, IItemTypes items, IOrder orderHelper)
        {
            _paymentRepo = paymentRepo;
            _mapper = mapper;
            _items = items;
            _orderHelper = orderHelper;
        }
        [HttpGet("{id}/balance")]
        public ActionResult GetBalance(int id)
        {
            var user = _paymentRepo.GetBalanceById(id);
            if(user != null)
            {
                return Ok(_mapper.Map<UserDto>(user));
            }
            return NotFound("No Account could be found with this Id");
        }

        [HttpPost]
        public ActionResult RegisterAccount([FromBody]UserPostDto user)
        {
            if(user.Name == null) { return BadRequest(); }
            User createdUser = _paymentRepo.AddNewUser(_mapper.Map<User>(user));
            return Created("here",createdUser);
        }

        [HttpPatch("{id}")]
        public ActionResult TopUpAccount(int id , [FromBody]TopUp topUp)
        {
            if(topUp.Amount == 0) { return BadRequest(); }
            User updatedUser = _paymentRepo.UpdateUserTopUp(id, topUp.Amount);
            return Ok(_mapper.Map<User>(updatedUser));
        }

        [HttpPatch("{id}/purchase")]
        public ActionResult PurchaseItems(int id, [FromBody]Dictionary<string, int> requestedItems)
        {
            if (!_orderHelper.CheckItemsRequestedInItemTypes(requestedItems)){ return BadRequest("Requested item doesn't exist"); }
            _orderHelper.CalculateBasket(requestedItems);
            double balance = _mapper.Map<UserDto>(_paymentRepo.GetBalanceById(id)).Balance;

            if (_orderHelper.CheckAccountHasEnoughBalance(balance)) { return BadRequest("Not enough funds"); }
            return Ok(_paymentRepo.UpdateUserPurchase(id, _orderHelper.basketTotal));
        }
    }
}