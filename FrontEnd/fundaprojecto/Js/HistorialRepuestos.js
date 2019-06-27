

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
                        <h2 class="Main-Subtitle">Id Etapa : </h2>\
                        <p class="Main-Date">'+localStorage.getItem('id_etapa')+'</p>\
                    </div>\
					');
			
			},
			
		});
	
});

$(document).ready(function(){
    $('#boton_voler').click(function(){
        
        localStorage.setItem('id_etapa',' ');
        document.getElementById("boton_voler").href = "Etapas-Producto.html";
       
    })
});

$(document).ready(function(){
    $('#AgregarEtapa').click(function(){
        
        document.getElementById("AgregarEtapa").href = "ResgistrarUsoRepuesto.html";
       
    })
});


