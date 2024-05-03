class Documento {   // eslint-disable-line no-unused-vars

    constructor(data) {
     this.data = data
   }
 
   id() {
       return this.data.id;
     }
     nombre() {
       return this.data.nombre;
     }
     ruta() {
       return this.data.ruta;
     }

     idVenta(){
        return this.data.idVenta;
     }
     file(){
        return this.data.file;
     }
}
