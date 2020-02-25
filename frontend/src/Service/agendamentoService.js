import { http } from "./config.js";

export default {
    listarAgendamentos: () => {
        return http.get("/Agendamentos");
    },

    salvar: agendamento => {
        return http.post("/Agendamentos", agendamento);
    }

};