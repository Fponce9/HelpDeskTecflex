$(function(){
	//GET/READ
	
		var $un_tbody = $('#a_tbody');
		$.ajax({
			type: 'GET',
			url:'http://localhost:50086/api/Productos',
			contentType: 'application/json',
			success: function(response) {
                console.log(response);
                localStorage.setItem('tamanio_productos',response.length);
                $.each(response, function(i, productos){
                    
					$un_tbody.append('\
							<tr class="Main-Fila">\
								<td class="Main-Columna ">' + productos.IdProducto + '</td>\
                                <td class="Main-Columna ">' + productos.NombreProducto + '</td>\
                                <td class="Main-Columna ">' + productos.FechaVenta + '</td>\
                                <td class="Main-Columna ">' + productos.DuracionGarantia + '<td>\
                                <td> <a href="#" class="Table-Boton" id= "ver_etapa" onclick = "SRProducto(this,'+productos.IdProducto+')">ver</a></td>\
                            </tr>\
						');
				});
			},
			
		});
	
});


$(function(){
	//GET/READ
	
		var $label = $('#ruc_pro');
		$.ajax({
			type: 'GET',
			url:'http://localhost:50086/api/Productos',
			contentType: 'application/json',
			success: function(response) {
                console.log(response);
                    
				$label.append('\
                    <div class="Main-NameProducto2">\
                        <h2 class="Main-Subtitle">Ruc: </h2>\
                        <p class="Main-Date">'+localStorage.getItem('RUC')+'</p>\
                    </div>\
					');
			},
			
		});
	
});



function SRProducto(element, id_producto){
	console.log(id_producto);
	localStorage.setItem('id_producto', id_producto);
	element.href = "Solicitud-Reparacion-Producto.html";
}


$(document).ready(function(){
    $('#volver_vli').click(function(){
        
        document.getElementById("volver_vli").href = "BuscarCliente-Datos.html";
       
    })
});



