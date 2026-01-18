type WeatherProps = {
  city: string;
  temperature: number;
  condition: string;
  updatedAt: string;
};

export function WeatherCard({
  city,
  temperature,
  condition,
  updatedAt,
}: WeatherProps) {
  return (
    <div
      className="
        bg-white
        rounded-2xl
        shadow-md
        p-6
        w-full
        max-w-md
        text-center
        transform
        transition-all
        duration-300
        ease-out
        hover:scale-[1.02]
        hover:shadow-lg
      "
    >
      <h2 className="text-2xl font-semibold text-gray-800">
        {city}
      </h2>

      <p className="text-5xl font-bold text-blue-600 my-4">
        {temperature}°C
      </p>

      <p className="text-gray-600">
        {condition}
      </p>

      <p className="text-xs text-gray-400 mt-4">
        Última atualização: {updatedAt}
      </p>
    </div>
  );
}