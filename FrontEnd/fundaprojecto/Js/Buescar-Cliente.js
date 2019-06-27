$(document).ready(function(){
    $('#boton_cliente').click(function(){
        var ruc =document.getElementById("cliente_ruc").value.toString();
        if(ruc != ""){
            if(ruc.length == 11){
                localStorage.clear();
                localStorage.setItem('RUC',ruc);
                document.getElementById("boton_cliente").href = "BuscarCliente-Datos.html";
                console.log(localStorage.getItem("RUC"));   
            }
            else{
                alert("RUC ingresado de manera erronera.")
            }
        }
        else{
            alert("Tienes que ingresar un RUC.")
        }
    })
});
