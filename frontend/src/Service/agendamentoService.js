import { http } from "./config";

export default {
    listarAgendamentos: () => {
        return http.get("/Agendamentos");
    },

    salvar: agendamento => {
        return http.post("/Agendamentos", agendamento);
    }

};