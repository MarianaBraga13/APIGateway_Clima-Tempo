import axios from "axios";

const api = axios.create({
  baseURL: import.meta.env.VITE_API_BASE_URL,
  headers: {
    "X-API-Key": import.meta.env.VITE_API_KEY,
  },
});

export const getWeather = async (city: string) => {
  const response = await api.get(`/weather/${city}`);
  return response.data;
};