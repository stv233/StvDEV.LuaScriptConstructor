
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

StvDEVScriptConstructor.Less = function(e, value1, value2)
	return (value1 < value2)
end 

StvDEVScriptConstructor.GreaterOrEqual = function(e, value1, value2)
	return (value1 >= value2)
end 

StvDEVScriptConstructor.LessOrEqual = function(e, value1, value2)
	return (value1 <= value2)
end

StvDEVScriptConstructor.Equal = function(e, value1, value2)
	return (value1 == value2)
end

StvDEVScriptConstructor.And = function(e, value1, value2)
	return (value1 and value2)
end	

StvDEVScriptConstructor.Or = function(e, value1, value2)
	return (value1 or value2)
end

StvDEVScriptConstructor.Not = function(e, value1)
	return (not value1)
end



