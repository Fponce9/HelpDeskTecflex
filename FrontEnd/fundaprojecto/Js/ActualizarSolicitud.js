$(function(){
    //GET/READ
        var labels = ["I","NombreSolicitud","Descripcion","Cotizacion","FechaSolicitud","E","P"];
        var $cotizacion = document.getElementById("icoti");
        var $nombre = document.getElementById("iname");
        var $FechaIngreso = document.getElementById("ifecha");
        var $Descripción = document.getElementById("idescri");
        var aux = 0 
        $.ajax({
            type: 'GET',
			url:'http://localhost:50086/api/Solicitud_Reparacion/'+localStorage.getItem('id_solicitud')+'',
			contentType: 'application/json',
			success: function(response) {
                console.log(response);
                $.each(response, function(i, Solicitud){
					console.log(Solicitud);
                    if(labels[aux] == "NombreSolicitud"){
                        $nombre.value = Solicitud
                    }
                    if(labels[aux] == "Descripcion"){
                        $Descripción.value = Solicitud
                    }
                    if(labels[aux] == "Cotizacion"){
                        $cotizacion.value = Solicitud
                    }   
                    if(labels[aux] == "FechaSolicitud"){
                        $FechaIngreso.value = Solicitud
                    }   


                    aux += 1
				});
			},
			
        });
	
});


$(document).ready(function(){
    $('#boton_voler').click(function(){
        
            document.getElementById("boton_voler").href = "Solicitud-Reparacion-Producto.html";
       
    })
});
