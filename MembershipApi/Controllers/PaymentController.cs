using AutoMapper;
using MembershipApi.Data;
using MembershipApi.Dtos;
using MembershipApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MembershipApi.Controllers
{
    [Route("api/payments")]
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


        [HttpPost("/register")]
        public ActionResult RegisterAccount([FromBody]UserPostDto user)
        {
            _paymentRepo.AddNewUser(_mapper.Map<User>(user));
            return Created("here",user);
        }
    }
}