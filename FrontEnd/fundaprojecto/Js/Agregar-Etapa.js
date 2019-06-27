$(document).ready(function(){
    $('#add-order').click(function(){
		var etapa ={
			Tecnico_DNI: "98568545",
			Fecha: document.getElementById("fecha").value,
			Descripcion:document.getElementById("descripcion").value,
			Nombre_Etapa:document.getElementById("nombre").value,
			Solicitud_Reparacion_idProblema: localStorage.getItem(id_solicitud)
			};
			$.ajax({
				type:'POST',
				url: 'http://localhost:50086/api/Etapas',
				data:etapa
			
			});
		document.getElementById("add-order").href = "Etapas-Producto.html";
    })
});


