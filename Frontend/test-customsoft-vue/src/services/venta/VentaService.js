import axios from 'axios';


export const VentaService = {


  getAll() { 
      return axios.get('/ventas/getAll').then(res => res.data);
    },
    save(venta){
     return  axios.post('/ventas/save', venta).then(res => res.data);
    },
    update(venta){
      return  axios.put('/ventas/update', venta, {
        headers: {
          'Access-Control-Allow-Origin': '*'        }
      }).then(res => res.data);
     },
     delete(venta){
      return  axios.delete('/ventas/delete/'+venta).then(res => res.data);
     },
     findById(id){
      return axios.get('/ventas/get/'+id).then(res => res.data);

     } 


    
   
};


export default {
  VentaService
};
