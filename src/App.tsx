import { useState } from "react";
import { getWeather } from "./services/weatherApi";
import { WeatherCard } from "./components/WeatherCard";

export default function App() {
  const [city, setCity] = useState("");
  const [weather, setWeather] = useState<any>(null);
  const [loading, setLoading] = useState(false);

  async function handleSearch() {
    if (!city) return;

    setLoading(true);
    try {

      //Teste da resposta da API
      const data = await getWeather(city);

      //console.log("Resposta da API:", data);

      setWeather(data);
    } catch {
      alert("Erro ao consultar clima.");
    } finally {
      setLoading(false);
    }
  }

  return (
    <div
      className="
        min-h-screen
        bg-gradient-to-br
        from-gray-100
        to-blue-50
        flex
        items-center
        justify-center
        px-4
      "
    >
      <div className="w-full max-w-lg space-y-6 text-center">
        {/* HEADER */}
        <header className="space-y-1">
          <h1 className="text-3xl font-bold text-gray-800">
            Weather Gateway Demo
          </h1>
          <p className="text-sm text-gray-500">
            Integração React + .NET Core API com autenticação
          </p>
        </header>

        {/* INPUT + BOTÃO */}
        <div className="flex gap-2">
          <input
            className="
              flex-1
              border
              border-gray-300
              rounded-lg
              px-4
              py-2
              focus:outline-none
              focus:ring-2
              focus:ring-blue-500
              focus:border-blue-500
              transition
            "
            placeholder="Digite o nome da cidade"
            value={city}
            onChange={(e) => setCity(e.target.value)}
          />

          <button
            onClick={handleSearch}
            className="
              bg-blue-600
              text-white
              px-5
              py-2
              rounded-lg
              transition-all
              duration-200
              hover:bg-blue-700
              hover:shadow-md
              active:scale-95
            "
          >
            Buscar
          </button>
        </div>

        {/* LOADING */}
        {loading && (
          <p className="text-gray-500 animate-pulse">
            Consultando clima...
          </p>
        )}

        {/* RESULTADO */}
        {weather && (
          <WeatherCard
            country={weather.country}
            city={weather.city}
            temperature={weather.temperature}
            condition={weather.condition}
            updatedAt={weather.updatedAt}
          />
        )}

        {/* FOOTER */}
        <footer className="text-xs text-gray-400 pt-2">
          API protegida por autenticação via <strong>X-API-Key</strong>
        </footer>
      </div>
    </div>
  );
}