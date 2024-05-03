<template>
    <div class="pa-4 text-center">
        <v-dialog v-model="localShow" width="600px" max-width="600">

            <v-card prepend-icon="mdi-file-pdf-box" title="Archivos ">
                <v-card-text>

                    <v-row dense>
                        <v-treeview :items="localItems">

                            
                            <template v-slot:prepend="{ item, open }">
                                <v-icon v-if="(!item.file)">
                                    {{ open ? 'mdi-folder-open' : 'mdi-folder' }}
                                </v-icon>
                                <v-icon @click="$emit('descargaArchivoEvt', item.id)" v-else>
                                    mdi-download-circle-outline
                                </v-icon>
                            </template>

                        </v-treeview>
                    </v-row>



                    <v-divider></v-divider>
                    <v-spacer></v-spacer>

                    <v-row>

                        <v-col cols="12" md="6" sm="12">
                            <v-file-input  v-model="documentoSelected.file" accept="application/pdf" label="Archivo pdf"></v-file-input>

                        </v-col>


                        
                    </v-row>
                    <v-row>
                        <v-col cols="12" md="6" sm="9">

                            <v-btn color="primary" text="Cerrar" variant="tonal" @click="localShow = false;"></v-btn>
                        </v-col>
                        <v-col cols="12" md="6" sm="3">

                            <v-btn color="primary" text="Agrega archivo" variant="tonal"
                                @click="agregaArchivoNuevo()"></v-btn>
                        </v-col>

                    </v-row>

                </v-card-text>

                <v-divider></v-divider>


            </v-card>
        </v-dialog>
    </div>
</template>

<script>

import NodeTree from '../models/NodeTree';
import Documento from '../models/Documento';   // eslint-disable-line no-unused-vars

import { VTreeview } from 'vuetify/labs/VTreeview'

export default {
    props: {
        items: NodeTree,
        show: Boolean,
        venta: Number
    },
    emits: ['update:show', 'descargaArchivoEvt', 'update:items', 'update:venta', 'agregaArchivoNuevo'],
    components: {
        VTreeview
    }, methods: {

        agregaArchivoNuevo(){
            this.documentoSelected.idVenta=this.localVenta;
            console.log(this.localVenta+" "+ this.venta)
            this.$emit('agregaArchivoNuevo', this.documentoSelected); 
            this.localShow = false;
        },
    },
    watch: {
        
        localShow(newValue) {
            this.$emit('update:show', newValue)
        },
        show(newValue) {
            this.localShow = newValue
        },
        localItems: {
            handler: function (newVal) {
                this.$emit('update:items', newVal)
            },
            deep: true
        },
        items(newValue) {
            this.localItems = newValue

        },
        localVenta  (newVal) {
                this.$emit('update:venta', newVal)
            },
        venta(newValue) {
            this.localVenta = newValue

        },
         
    },
    name: 'dialogform',
    mounted() {
        this.documentoSelected.idVenta = this.localVenta;
     },
    data: () => ({
        localShow: false,
        localVenta: -1,
        localItems: [],
        documentoSelected: {},
         



    }),
}
</script>