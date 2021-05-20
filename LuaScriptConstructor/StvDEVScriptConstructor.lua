
StvDEVScriptConstructor = {}

StvDEVScriptConstructor.Addition = function(e, value1, value2)
	return value1 + value2
end

StvDEVScriptConstructor.Subtraction = function(e, value1, value2)
	return value1 - value2
end

StvDEVScriptConstructor.Multiplication = function(e, value1, value2)
	return value1 * value2
end

StvDEVScriptConstructor.Division = function(e, value1, value2)
	return value1 / value2
end

StvDEVScriptConstructor.Modulo = function(e, value1, value2)
	return value1 % value2
end

StvDEVScriptConstructor.Greater = function(e, value1, value2)
	return (value1 > value2	)
end
