<template>
    <v-container>

        <v-row class="text-center">

            <v-col cols="12">
                <v-sheet :elevation="5">

                    <table-generic v-model="ventas" :idItem="'idVenta'" :titulo="'Ventas'"  @addItemEvt="agregaVenta()"
                        @actionEditEvt="(idVenta) => editarVenta(idVenta)"
                        @actionDelEvt="(idVenta) => eliminarVenta(idVenta)"
                        @actionEvt="(idVenta) => verArchivos(idVenta)"> </table-generic>
                     
                </v-sheet>
            </v-col>
        </v-row>
    </v-container>
    <dialog-form v-model:venta="ventaSelected"  v-model:show="showForm"  @updateVentaEvt="  guardarVenta()" >

     </dialog-form>


        <dialog-files v-model:venta="idVentaSelected"  v-model:items="documentosSelected" 
         v-model:show="showFormFiles" 
         @descargaArchivoEvt="(idDoc) => descargaArchivo(idDoc)"
         @agregaArchivoNuevo="(docum) => guardarArchivo(docum)">

    </dialog-files>
</template>

<script>
 import {
    VentaService
} from '../../services/venta/VentaService';

import {
 DocumentoService
} from '../../services/venta/DocumentoService';

export default {
    mounted() {
        this.refresh();
    },
    components: {

    }, methods: {
        descargaArchivo(idDoc){
            console.log(idDoc)
            DocumentoService.descarga(idDoc);

        },
        guardarArchivo(documento){
           

            DocumentoService.save(documento).then(res =>{

                console.log(res)
                this.showFormFiles=false;            })
        },
        verArchivos(idVenta) {
           DocumentoService.getAllByVenta(idVenta).then(res =>{
                    this.documentosSelected=res;
                    this.idVentaSelected=idVenta;
                    this.showFormFiles=true;

                            })
        },

        editarVenta(idVenta) {
            console.log("editarVta " + idVenta)
           
            
            VentaService.findById(idVenta).then(res =>{
                    this.ventaSelected=res;
                    this.showForm=true;

            })       
            this.showForm=true;
         },

        agregaVenta(idVenta) {
            this.ventaSelected={};
            console.log('add vent' + idVenta)
            this.showForm=true;
        },
        eliminarVenta(idVenta) {
            VentaService.delete(idVenta).then(res =>{ // eslint-disable-line no-unused-vars
                     this.refresh()

            }) 
        },
        guardarVenta( ){
            if(this.ventaSelected.idVenta!=null){
                VentaService.update(this.ventaSelected).then(res =>{ // eslint-disable-line no-unused-vars
                     this.refresh()

            })
            }else{
                VentaService.save(this.ventaSelected).then(res =>{ // eslint-disable-line no-unused-vars
                this.refresh()
            }) 
            }
            

        },
        refresh() {

            console.log(this.showForm);
            VentaService.getAll().then(res => {
                this.ventas = res;
               
                console.log(this.showForm);


            })
        }
    },
    name: 'ventasView',

    data: () => ({
        ventas: [],
        showForm:false,
        ventaSelected:{},
        documentosSelected:[],
        showFormFiles:false,
        idVentaSelected:-1
    }),
}
</script>