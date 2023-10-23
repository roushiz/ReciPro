#version 430 core

//#pragma optionNV(ifcvt none)
//#pragma optionNV(inline all)
//#pragma optionNV(strict on)
//#pragma optionNV(unroll all)

layout(early_fragment_tests) in;

#define MAX_FRAGMENTS ##

uniform uint MaxNodes;

struct NodeType {
	vec4 color;
	float depth;
	uint next;
};

layout(binding = 0, r32ui) uniform uimage2D headPointers;
layout(binding = 0, offset = 0) uniform atomic_uint nextNodeCounter;
layout(binding = 0, std430) buffer linkedLists {
	NodeType nodes[];
};

subroutine void RenderPassType();
subroutine uniform RenderPassType RenderPass;

// Material properties
uniform float Emission = 0.2;
uniform float Ambient = 0.2;
uniform float Diffuse = 0.7;
uniform float Specular = 0.5;
uniform vec3 SpecularColor = vec3(1.0);
uniform float SpecularPower = 128.0;
uniform vec3 BgColor = vec3(1, 1, 1);
uniform bool IgnoreNormalSides = false;

//Depth Cueing
uniform bool DepthCueing = false;
uniform float Far = -2.5;
uniform float Near = 0.5;

uniform sampler2D Texture;

// Input from vertex shader
//in VertexData
//{
in float fWithTexture;//-1: without texture, +1: with texture
in vec3 fNormal;//Normal direction
in vec3 fLight;//Light direction
in vec3 fView;//View direction
in vec4 fColor;//Color
in float fZ;//Depth
in vec2 fUv;//texture coordinates
//} fs_in;

/*layout(location = 0) */out vec4 FragColor;

vec4 setColor()
{
	vec3 c3;
	float a;
	//Without texture
	if (fWithTexture < 0.0)
	{
		// Normalize the incoming N, L, and V vectors
		vec3 normal = normalize(fNormal);
		vec3 light = normalize(fLight);
		vec3 view = normalize(fView);
		vec3 inColor = vec3(fColor);
		// Calculate R locally
		vec3 ref = reflect(-light, normal);

		// Compute the diffuse and specular components for each fragment
		vec3 ambient = Ambient * inColor;
		vec3 specular = pow(max(dot(ref, view), 0), SpecularPower) * Specular * SpecularColor;
		vec3 emission;
		vec3 diffuse;

		if (IgnoreNormalSides)
		{
			emission = max(abs(dot(normal, view)), 0) * Emission * inColor;
			diffuse = max(abs(dot(normal, light)), 0) * Diffuse * inColor;
		}
		else
		{
			emission = max(dot(normal, view), 0) * Emission * inColor;
			diffuse = max(dot(normal, light), 0) * Diffuse * inColor;
		}

		c3 = vec3(diffuse + specular + ambient + emission);
		a = fColor.a;
	}
	//With texture
	else
	{
		vec4 c = texture2D(Texture, fUv);
		c3 = vec3(c);
		a = c.a;
	}

	if (DepthCueing)
		if (fZ < Near)
		{
			if (fZ < Far)
				c3 = BgColor;
			else
				c3 = mix(c3, BgColor, (Near - fZ) / (Near - Far));
		}

	return vec4(c3, a);// Write final color to the framebuffer
}

subroutine(RenderPassType)
void passOIT1()
{
	// Get the index of the next empty slot in the buffer
	uint nodeIdx = atomicCounterIncrement(nextNodeCounter);

	// Is our buffer full?  If so, we don't add the fragment to the list.
	if (nodeIdx < MaxNodes) {
		// Our fragment will be the new head of the linked list, so
		// replace the value at gl_FragCoord.xy with our new node's
		// index.  We use imageAtomicExchange to make sure that this
		// is an atomic operation.  The return value is the old head
		// of the list (the previous value), which will become the
		// next element in the list once our node is inserted.
		uint prevHead = imageAtomicExchange(headPointers, ivec2(gl_FragCoord.xy), nodeIdx);

		// Here we set the color and depth of this new node to the color
		// and depth of the fragment.  The next pointer, points to the
		// previous head of the list.
		nodes[nodeIdx].color = setColor();
		nodes[nodeIdx].depth = gl_FragCoord.z;
		nodes[nodeIdx].next = prevHead;
	}
	//FragColor = nodes[nodeIdx].color;
}

subroutine(RenderPassType)
void passOIT2()
{
	NodeType frags[MAX_FRAGMENTS];

	// Get the index of the head of the list
	uint n = imageLoad(headPointers, ivec2(gl_FragCoord.xy)).r;

	// Copy the linked list for this fragment into an array
	int count = 0;
	while (n != 0xffffffff && count < MAX_FRAGMENTS) {
		frags[count] = nodes[n];
		n = frags[count].next;
		count++;
	}

	// Sort the array by depth using insertion sort (largest
	// to smallest).

	//insert sort
	/*
	for( uint i = 1; i < count; i++ )
	{
	NodeType toInsert = frags[i];
	uint j = i;
	while( j > 0 && toInsert.depth > frags[j-1].depth ) {
	frags[j] = frags[j-1];
	j--;
	}
	frags[j] = toInsert;
	}*/

	//selection sort
	/*
	int max;
	NodeType tempNode;
	int j, i;
	for(j = 0; j < count - 1; j++)
	{
	max = j;
	for(  i = j + 1; i < count; i++)
	{
	if(frags[i].depth > frags[max].depth)
	{
	max = i;
	}
	}
	if(max != j)
	{
	tempNode = frags[j];
	frags[j] = frags[max];
	frags[max] = tempNode;
	}
	}
	*/


	//bubble sort
	/*
	int j, i;
	NodeType tempNode;
	for(i = 0; i < count - 1; i++)
	{
	for(j = 0; j < count - i - 1; j++)
	{
	if(frags[j].depth < frags[j+1].depth)
	{
	tempNode = frags[j];
	frags[j] = frags[j+1];
	frags[j+1] = tempNode;
	}
	}
	}
	*/


	//merge sort
	/*
	int i, j1, j2, k;
	int a, b, c;
	int step = 1;
	NodeType leftArray[MAX_FRAGMENTS / 2]; //for merge sort

	while (step <= count)
	{
		i = 0;
		while (i < count - step)
		{
			////////////////////////////////////////////////////////////////////////
			//merge(step, i, i + step, min(i + step + step, count));
			a = i;
			b = i + step;
			c = (i + step + step) >= count ? count : (i + step + step);

			for (k = 0; k < step; k++)
				leftArray[k] = frags[a + k];

			j1 = 0;
			j2 = 0;
			for (k = a; k < c; k++)
			{
				if (b + j1 >= c || (j2 < step && leftArray[j2].depth > frags[b + j1].depth))
					frags[k] = leftArray[j2++];
				else
					frags[k] = frags[b + j1++];
			}
			////////////////////////////////////////////////////////////////////////
			i += 2 * step;
		}
		step *= 2;
	}
	*/

	//shell sort
	int i, j;
	NodeType tmp;
	int inc = count / 2;
	while (inc > 0)
	{
		for (i = inc; i < count; i++)
		{
			tmp = frags[i];
			j = i;
			while (j >= inc && frags[j - inc].depth < tmp.depth)
			{
				frags[j] = frags[j - inc];
				j -= inc;
			}
			frags[j] = tmp;
		}
		inc = int(inc / 2.2 + 0.5);
	}

	// Traverse the array, and combine the colors using the alpha channel.
	vec4 color = vec4(BgColor,1);
	for (int i = 0; i < count; i++)
		color = mix(color, frags[i].color, frags[i].color.a);
	color.a = 1;
	// Output the final color
	FragColor = color;
}

subroutine(RenderPassType)
void passNormal()
{
	FragColor = setColor();// Write final color to the framebuffer
}

void main()
{
	RenderPass();
}




