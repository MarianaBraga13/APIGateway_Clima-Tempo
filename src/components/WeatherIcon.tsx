type Props = {
  condition: string;
};

export function WeatherIcon({ condition }: Props) {
  const normalized = condition.toLowerCase();

  if (normalized.includes("chuva")) {
    return (
      <div className="relative text-blue-500 text-6xl animate-bounce">
        ☔
        <span className="absolute left-1/2 top-full text-blue-400 animate-ping">
          💧
        </span>
      </div>
    );
  }

  if (normalized.includes("nublado") || normalized.includes("encoberto")) {
    return (
      <div className="text-gray-400 text-6xl animate-pulse">
        ☁️
      </div>
    );
  }

  if (normalized.includes("nevoeiro") || normalized.includes("névoa")) {
    return (
      <div className="text-gray-300 text-6xl animate-fade">
        🌫️
      </div>
    );
  }

  if (normalized.includes("sol") || normalized.includes("limpo")) {
    return (
      <div className="text-yellow-400 text-6xl animate-spin-slow">
        ☀️
      </div>
    );
  }

  return (
    <div className="text-5xl">
      🌡️
    </div>
  );
}