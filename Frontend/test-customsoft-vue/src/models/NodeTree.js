class NodeTree {   // eslint-disable-line no-unused-vars

    constructor(data) {
     this.data = data
   }
 
   id() {
       return this.data.id;
     }
     title() {
       return this.data.title;
     }
     children() {
       return this.data.children;
     }
}
