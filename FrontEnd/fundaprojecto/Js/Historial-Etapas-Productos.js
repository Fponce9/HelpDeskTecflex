$(function(){
	//GET/READ
		var $un_tbody = $('#a_tbody');
		$.ajax({
			type: 'GET',
			url:'http://localhost:50086/api/EtapasSolicitudReparacion/'+localStorage.getItem('id_solicitud')+'',
			contentType: 'application/json',
			success: function(response) {
                console.log(response);
				$.each(response, function(i, solicitud){
                    
					$un_tbody.append('\
							<tr class="Main-Fila">\
								<td class="Main-Columna ">' + solicitud.IdEtapa + '</td>\
                            	<td class="Main-Columna ">' + solicitud.Descripcion + '</td>\
	                            <td class="Main-Columna ">' + solicitud.FechaIngreso + '</td>\
    	                        <td class="Main-Columna ">' + solicitud.Tecnico_DNI + '<td>\
								<td class="Main-Columna ">' + solicitud.Nombre_Etapa+ '<td>\
								<td> <a href="#" class="Table-Boton" id= "ver_etapa_producto" onclick = "SRProducto(this,'+solicitud.IdEtapa+')">ver</a></td>\
            	            </tr>\
						');
						
				});
			
			
			},
			
		});
	
});

function SRProducto(element, IdEtapa){
	console.log(IdEtapa);
	localStorage.setItem('id_etapa', IdEtapa);
	element.href = "HistorialRepuestos.html";
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
                        <h2 class="Main-Subtitle">Id Solicitud : </h2>\
                        <p class="Main-Date">'+localStorage.getItem('id_solicitud')+'</p>\
                    </div>\
					');
			
			},
			
		});
	
});

$(document).ready(function(){
    $('#boton_voler').click(function(){
        
        localStorage.setItem('id_solicitud',' ');
        document.getElementById("boton_voler").href = "Solicitud-Reparacion-Producto.html";
       
    })
});

$(document).ready(function(){
    $('#AgregarEtapa').click(function(){
        
        document.getElementById("AgregarEtapa").href = "Registrar-Nueva-Etapas.html";
       
    })
});








