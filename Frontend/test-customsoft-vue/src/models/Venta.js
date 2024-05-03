class Venta {   // eslint-disable-line no-unused-vars

         constructor(data) {
          this.data = data
        }
      
        descripcion() {
            return this.data.descripcion;
          }
          fechaVenta() {
            return this.data.fechaVenta;
          }
          idVenta() {
            return this.data.idVenta;
          }
  }
  