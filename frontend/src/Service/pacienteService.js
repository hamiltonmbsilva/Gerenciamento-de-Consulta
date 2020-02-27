import { http } from "./config.js";

export default {
  listar: () => {
    return http.get("/Pacientes");
  },

  salvar: paciente => {
    return http.post("/Pacientes", paciente);
  }
};