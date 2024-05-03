<template>
    <v-data-table class="elevation-1" height="500px" :headers="headers" :items="localValue" :header-props="headerProps"
        :row-props="rowProps">
        <template v-slot:top>
            <v-toolbar flat>
                <v-toolbar-title>{{ titulo }}</v-toolbar-title>

                <v-btn @click="$emit('addItemEvt')" icon>
                    <v-icon>mdi-pencil-plus</v-icon>
                </v-btn>

            </v-toolbar>
        </template>
        <template v-slot:headers="{ columns }">
            <tr>
                <template v-for="column in columns" :key="column.key">
                    <th>
                        <span class="mr-2 cursor-pointer">{{ column.text }} </span>
                    </th>
                </template>
            </tr>
        </template>

        <template v-slot:[`item.action`]="{ item }">
            <td>
            <v-btn @click="$emit('actionEvt', item[idItem])" icon>
                    <v-icon>mdi-file-eye-outline</v-icon>
                </v-btn>
                &nbsp;
                <v-btn @click="$emit('actionEditEvt', item[idItem])" icon>
                    <v-icon>mdi-pencil</v-icon>
                </v-btn>

                &nbsp;
                <v-btn @click="$emit('actionDelEvt', item[idItem])" icon>
                    <v-icon>mdi-pencil-minus</v-icon>
                </v-btn>

            </td>
         </template>


        <template v-slot:bottom>

        </template>


    </v-data-table>

</template>

<script>


export default {

    props: {
        modelValue: {},
        titulo: String,
        idItem: String
    }, emits: ['update:modelValue', 'addItemEvt', 'actionEvt','actionEditEvt','actionDelEvt'],
    data() {
        return {
            localValue: this.modelValue,
            headerProps: {
                align: 'center',
                sortable: false
            },
            rowProps: {
                align: 'left',
            },

        }
    },
    watch: {
        localValue(newValue) {
            this.$emit('update:modelValue', newValue)
        },
        modelValue(newValue) {
            this.localValue = newValue
        }
    },
    methods: {

    },

    computed: {
        headers: function () {
            let s = new Set();

            this.localValue.forEach(item => {
                for (let f in item) {
                    s.add(f)
                }
            });

            let headersR = Array.from(s).map(a => {
                return {
                    text: a,
                    value: a

                }
            });
            //Agregar exta columna para los botones de accion
            headersR.push({ text: "Acciones", value: "action" });
            return headersR;
        }

    }


}
</script>