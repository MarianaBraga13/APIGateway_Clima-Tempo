import axios from "axios";
//Teste para ter certeza que está enviando a API KEY corretamente
//console.log("API KEY:", import.meta.env.VITE_API_KEY);

const api = axios.create({
  baseURL: import.meta.env.VITE_API_BASE_URL,
  headers: {
    "X-API-Key": import.meta.env.VITE_API_KEY,
  },
});

export const getWeather = async (city: string) => {
  const response = await api.get("/weather", {
    params: { city },
  });

  return response.data;
};