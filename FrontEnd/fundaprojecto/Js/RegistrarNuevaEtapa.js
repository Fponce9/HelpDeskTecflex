$(function(){
	//GET/READ
        var labels = ["I","N","F","DuracionCotizacion","C","S"];
        var $cotizacion = document.getElementById("icoti");
        var aux = 0;
		$.ajax({
            type: 'GET',
            
			url:'http://localhost:50086/api/Productos/'+localStorage.getItem('id_producto')+'',
			contentType: 'application/json',
			success: function(response) {
                console.log(response);
                $.each(response, function(i, producto){
					console.log(producto);
                    if(labels[aux] == "DuracionCotizacion"){
                        if(producto  > 0){
                            $cotizacion.value=0
                            $cotizacion.disabled = true;
                        }
                    }

                    aux += 1
				});
				
			},
			
        });
	
});


$(document).ready(function(){
    $('#boton_voler').click(function(){
        
            document.getElementById("boton_voler").href = "Etapas-Producto.html";
       
    })
});
