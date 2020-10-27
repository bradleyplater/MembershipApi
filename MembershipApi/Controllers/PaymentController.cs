using AutoMapper;
using MembershipApi.Data;
using MembershipApi.Dtos;
using MembershipApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MembershipApi.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class PaymentController : Controller
    {
        private readonly IPaymentRepo _paymentRepo;
        private readonly IMapper _mapper;

        public PaymentController(IPaymentRepo paymentRepo, IMapper mapper)
        {
            _paymentRepo = paymentRepo;
            _mapper = mapper;
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

        //test
        [HttpPost]
        public ActionResult RegisterAccount([FromBody]UserPostDto user)
        {
            if(user.Name == null) { return BadRequest(); }
            User createdUser = _paymentRepo.AddNewUser(_mapper.Map<User>(user));
            return Created("here",createdUser);
        }
    }
}