<template>
    <div class="pa-4 text-center">
        <v-dialog persistent v-model="localShow" width="600px" max-width="600">

            <v-card prepend-icon="mdi-awning" title="Ventas">
                <v-card-text>
                    <v-row dense>

                        <v-col cols="12" md="6" sm="6">
                            <v-text-field v-model="localVenta.idVenta" disabled name="idVenta" id="idVenta"
                                type="number" hint="Id" label="Id"></v-text-field>
                        </v-col>
                        <v-col cols="12" md="6" sm="6">

                            <v-text-field   v-model="localVenta.fechaVenta"  name="fecha" id="fecha" type="date"
                                hint="Fecha de la venta" label="Fecha"></v-text-field>
                        </v-col>
                    </v-row>
                    <v-row dense>
                        <v-col cols="12" md="12" sm="6">
                            <v-textarea v-model="localVenta.descripcion" name="descripcion" id="descripcion" required
                                hint="Descripción de la venta" label="Descripción"></v-textarea>
                        </v-col>






                    </v-row>


                </v-card-text>

                <v-divider></v-divider>

                <v-card-actions>
                    <v-spacer></v-spacer>

                    <v-btn text="Cancelar" variant="plain" @click="localShow = false"></v-btn>

                    <v-btn color="primary" text="Guardar" variant="tonal"
                        @click="$emit('updateVentaEvt', venta); localShow = false;"></v-btn>
                </v-card-actions>
            </v-card>
        </v-dialog>
    </div>
</template>

<script>

import Venta from '../models/Venta';

export default {
    props: {
        venta:   Venta,
        show: Boolean
    },
    emits: ['updateVentaEvt', 'update:show', 'update:venta'],
    components: {
    }, methods: {

    },
    watch: {
        localShow(newValue) {
            this.$emit('update:show', newValue)
        },
        show(newValue) {
            this.localShow = newValue
        },
        localVenta: {
            handler: function (newVal) {
                console.log("new Value is " + newVal)
                this.$emit('update:venta', newVal)
            },
            deep: true
        },
        venta(newValue) {
            this.localVenta = newValue

        }
    },
    name: 'dialogform',

    data: () => ({
        localShow: false,
        localVenta: {}

    }),
}
</script>
