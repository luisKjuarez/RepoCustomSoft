 
using Aplicacion.Venta.Commands;
using Aplicacion.Venta.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Modelos;
 
namespace TestCustomSoft.Controllers
{
    [ApiController]
    [Route("ventas")]
    public class VentasController : ControllerBase
    {

        private readonly ILogger<VentasController> _logger;
        private readonly ISender sender;

        public VentasController(ILogger<VentasController> logger, ISender sender)
        {
            _logger = logger;
            this.sender = sender;
        }



        [HttpGet("get/{idVenta}")]
        public async Task<TdVenta> GetById(int idVenta)
        {
            TdVenta venta = (TdVenta) await sender.Send(new GetVentaByID(idVenta));
            return venta;
        }


        [HttpGet]
        [Route("getAll")]
        public async Task<List<TdVenta>> GetAsync()
        {
            List<TdVenta> users = (List<TdVenta>)await sender.Send(new GetVentaQry());
            return users;
        }


        [HttpPost]
        [Route("save")]
        public TdVenta save(TdVenta venta)
        {
            sender.Send(new InsertVentaCmnd(venta));

            return venta;
        }


        [HttpDelete("delete/{idVenta}")]
        public int delete(int idVenta)
        {
            sender.Send(new DeleteVentaCmnd(idVenta));

            return idVenta;
        }


        [HttpPut]
        [Route("update")]
        public TdVenta update(TdVenta venta)
        {

            sender.Send(new UpdateVentaCmd(venta));

            return venta;
        }
    }
}
