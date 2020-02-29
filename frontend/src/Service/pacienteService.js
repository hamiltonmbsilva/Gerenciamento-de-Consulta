import { http } from "./config.js";

export default {
  listar: () => {
    return http.get("/Pacientes");
  },

  salvar: paciente => {
    return http.post("/Pacientes", paciente);
  },

  listarPaciente: () => {
    return http.get("/Pacientes/Select");
  },

  excluirPaciente: id =>{
    return http.delete("/Pacientes/"+id);
  },

  alterarPaciente: paciente =>{
    var url = `/Pacientes/${paciente.IdPaciente}`;
    return http.put(url, paciente);
  },

  buscarPacientePeloId: id =>{
    return http.get("/Pacientes/"+id);
  }

};