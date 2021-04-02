function removeElement(){
    let elems = document.querySelectorAll("div");
    let dialog = window.confirm("Are you sure you want to delete all history?");
    if(dialog){
        elems.forEach(element => {
            element.remove();
        });        
    }
    else{
        
    }
    return false;
}