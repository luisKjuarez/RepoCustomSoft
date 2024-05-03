import axios from 'axios';

let config = {
    headers: {
      "CSAPIKEY": "123456789ABC",
    }
  }
 export const DocumentoService = {

  getAllByVenta(idVenta) { 
      return axios.get('/documento/getAllByVenta/'+idVenta).then(res => res.data);
    } ,

    save(documento){
        const formData = new FormData();
        formData.append('documento', documento.file);
        return  axios.post('documento/upload/'+documento.idVenta,formData,config).then(res => res.data);
       },

    
        

        async descarga(idDoc) { 
          axios.get('/documento/download/'+idDoc , {responseType: 'arraybuffer'}).then(response => {
            let contentHeader=response.headers.get('content-disposition')+'';
            console.log(contentHeader)
             let fName=contentHeader.match(/filename=(.+);/)[1];

            console.log(fName);
            let blob = new Blob([response.data], { type: 'application/pdf' }),
              url = window.URL.createObjectURL(blob)

      const link = document.createElement('a');
            link.href = url;
            link.setAttribute('download', fName);
            document.body.appendChild(link);
            link.click();

          //  window.open(url) // Mostly the same, I was just experimenting with different approaches, tried link.click, iframe and other solutions
          })
          
          
         
        } ,
        
       
     
    
   
};


export default {
    DocumentoService
};
