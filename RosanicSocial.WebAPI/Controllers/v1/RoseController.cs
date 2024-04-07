using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RosanicSocial.WebAPI.Models;

namespace RosanicSocial.WebAPI.Controllers.v1 {
    
    public class RoseController : CustomControllerBase {
        //CreateRose
        //ReadRose
        //UpdateRose
        //DeleteRose

        [HttpGet]
        public async Task<ActionResult<Rose>> GetRose() {
            //GetFromDataBase
            Rose rose = new Rose();
            
            return rose;
        }

        /*
        [HttpPut]
        public async Task<IActionResult> PutRose() {

        }


        [HttpPost]
        public async ActionResult<Rose> PostRose() {
            Rose rose = new Rose();
            return CreatedAtAction("ReadRose", rose);
        }
        */
    }
}
