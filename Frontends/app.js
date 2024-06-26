document.addEventListener("DOMContentLoaded", () => {
  const newTareaBtn = document.getElementById("newTareaBtn");
  const tareaDialog = document.getElementById("tareaDialog");
  const tareaForm = document.getElementById("tareaForm");
  const tareaList = document.getElementById("tareaList");
  const dialogTitle = document.getElementById("dialogTitle");
  const cancelBtn = document.getElementById("cancelBtn");
  const completadaLabel = document.getElementById("completadaLabel");
  let editMode = false;
  let editTareaId = null;

  newTareaBtn.addEventListener("click", () => {
    openDialog();
  });

  cancelBtn.addEventListener("click", () => {
    closeDialog();
  });

  tareaForm.addEventListener("submit", (e) => {
    e.preventDefault();
    const tareaData = {
      titulo: tareaForm.titulo.value,
      descripcion: tareaForm.descripcion.value,
      completada: tareaForm.completada.checked,
    };
    if (editMode) {
      // Update employee
      tareaData.id = editTareaId;
      axios
        .put(`https://localhost:7054/api/tareas/${editTareaId}`, tareaData)
        .then((response) => {
          fetchTareas();
          closeDialog();
        })
        .catch((error) => console.error(error));
    } else {
      // Create new employee
      axios
        .post("https://localhost:7054/api/tareas", tareaData)
        .then((response) => {
          fetchTareas();
          closeDialog();
        })
        .catch((error) => console.error(error));
    }
  });

  function openDialog(tarea = null) {
    if (tarea) {
      editMode = true;
      editTareaId = tarea.id;
      dialogTitle.textContent = "Editar Tarea";
      tareaForm.titulo.value = tarea.titulo;
      tareaForm.descripcion.value = tarea.descripcion;
      tareaForm.completada.checked = tarea.completada;
      completadaLabel.style.display = "block";
      tareaForm.completada.disabled = false; // Habilitar el checkbox
    } else {
      editMode = false;
      dialogTitle.textContent = "Nueva Tarea";
      tareaForm.reset();
      completadaLabel.style.display = "block";
      tareaForm.completada.disabled = false; // Habilitar el checkbox
    }
    tareaDialog.style.display = "block";
  }

  function closeDialog() {
    tareaDialog.style.display = "none";
    editTareaId = null;
  }

  function fetchTareas() {
    axios
      .get("https://localhost:7054/api/tareas")
      .then((response) => {
        tareaList.innerHTML = "";
        response.data.forEach((tarea) => {
          const row = document.createElement("tr");
          row.innerHTML = `
                        <td>${tarea.id}</td>
                        <td>${tarea.titulo}</td>
                        <td>${tarea.descripcion}</td>
                        <td>${
                          tarea.completada ? "Tarea hecha" : "Falta por hacer"
                        }</td>
                        <td>
                            <button class="editBtn">Editar</button>
                            <button class="deleteBtn">Eliminar</button>
                        </td>
                    `;
          row
            .querySelector(".editBtn")
            .addEventListener("click", () => openDialog(tarea));
          row.querySelector(".deleteBtn").addEventListener("click", () => {
            axios
              .delete(`https://localhost:7054/api/tareas/${tarea.id}`)
              .then((response) => fetchTareas())
              .catch((error) => console.error(error));
          });
          tareaList.appendChild(row);
        });
      })
      .catch((error) => console.error(error));
  }

  fetchTareas();
});
