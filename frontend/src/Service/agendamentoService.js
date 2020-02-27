import { http } from "./config.js";

export default {
    listarAgendamentos: () => {
        return http.get("/Agendamento");
    },

    salvar: agendamento => {
        return http.post("/Agendamento", agendamento);
    }

};