type Props = {
  condition: string;
};

export function WeatherAnimation({ condition }: Props) {
  const text = condition.toLowerCase();

  if (text.includes("chuva")) {
    return (
      <div className="text-6xl text-blue-500 animate-bounce">
        ☔
      </div>
    );
  }

  if (text.includes("nublado") || text.includes("encoberto")) {
    return (
      <div className="text-6xl text-gray-400 animate-pulse">
        ☁️
      </div>
    );
  }

  if (text.includes("nevoeiro") || text.includes("névoa")) {
    return (
      <div className="text-6xl text-gray-300 animate-fade">
        🌫️
      </div>
    );
  }

  if (text.includes("sol") || text.includes("limpo")) {
    return (
      <div className="text-6xl text-yellow-400 animate-spin-slow">
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