$(function(){
	//GET/READ
		var $un_tbody = $('#a_tbody');
		$.ajax({
			type: 'GET',
			url:'http://localhost:50086/api/SolicitudReparacionProducto/'+localStorage.getItem('id_producto')+'',
			contentType: 'application/json',
			success: function(response) {
				console.log('http://localhost:50086/api/SolicitudReparacionProducto/'+localStorage.getItem('id_producto')+'')
                console.log(response);
                $.each(response, function(i, solicitud){
                    
					$un_tbody.append('\
							<tr class="Main-Fila">\
								<td class="Main-Columna ">' + solicitud.IdSolicitud + '</td>\
                                <td class="Main-Columna ">' + solicitud.NombreSolicitud + '</td>\
                                <td class="Main-Columna ">' + solicitud.Descripcion + '</td>\
                                <td class="Main-Columna ">' + solicitud.Cotizacion + '<td>\
                                <td class="Main-Columna ">' + solicitud.FechaSolicitud + '<td>\
								<td> <a href="#" class="Table-Boton" id= "ver_etapa_producto" onclick = "SRProducto(this,'+solicitud.IdSolicitud+')">ver</a></td>\
								<td> <a href="#" class="Table-Boton" id= "ver_etapa_producto" onclick = "SRActualizar(this,'+solicitud.IdSolicitud+')">actualizar</a></td>\
							</tr>\
						');
				});
			},
			
		});
	
});


function SRProducto(element, id_solicitud){
	console.log(id_solicitud);
	localStorage.setItem('id_solicitud', id_solicitud);
	element.href = "Etapas-Producto.html";
}
function SRActualizar(element, id_solicitud){
	console.log(id_solicitud);
	localStorage.setItem('id_solicitud', id_solicitud);
	element.href = "ActualizarSolicitud.html";
}
$(function(){
	//GET/READ
	
		var $label = $('#dato');
		$.ajax({
			type: 'GET',
			url:'http://localhost:50086/api/Productos',
			contentType: 'application/json',
			success: function(response) {
                console.log(response);
                    
				$label.append('\
                    <div class="Main-NameProducto2">\
                        <h2 class="Main-Subtitle">Id Producto Elegido : </h2>\
                        <p class="Main-Date">'+localStorage.getItem('id_producto')+'</p>\
                    </div>\
					');
			
			},
			
		});
	
});

$(document).ready(function(){
    $('#boton_voler').click(function(){
        
            localStorage.setItem('id_producto',' ');
            document.getElementById("boton_voler").href = "HistorialCompras.html";
       
    })
});

$(document).ready(function(){
    $('#Registrar_Nueva_Solicitud').click(function(){
        
            document.getElementById("Registrar_Nueva_Solicitud").href = "RegistrarNuevaSolicitud.html";
       
    })
});














