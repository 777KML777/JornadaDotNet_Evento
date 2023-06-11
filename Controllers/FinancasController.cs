// using Microsoft.AspNetCore.Mvc;
// using Application;

// namespace Api.Controllers
// {
//     [ApiController]
//     [Route("[controller]")]
//     public class DetailController : ControllerBase
//     {

//         private readonly DetailService _detailService;
//         public DetailController()
//         {
//             _detailService = new DetailService();
//         }

//         [HttpGet]
//         public string Get()
//         {
//             return "Success";
//         }

//         [HttpGet("UniqueDetail/{id}")]
//         public DetailDto Detail(int id) =>
//             _detailService.GetAllDetails(id);

//     }
// }