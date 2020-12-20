<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:template match="/">
		<html>
			<body>
				<h1>People</h1>
				<table class="big-table">
					<tr>
						<th rowspan="3" width="3%">Id</th>
						<th rowspan="3" width="15%">Name</th>
						<th rowspan="3" width="12%">Phone</th>
						<th rowspan="3" width="10%">Department</th>
					</tr>
					<tr>
						<th colspan="5">Address</th>
					</tr>
					<tr>
						<th width="12%">Street</th>
						<th width="12%">City</th>
						<th width="12%">State</th>
						<th width="12%">Zip</th>
						<th width="12%">Country</th>
					</tr>
					<xsl:for-each select="People/Person">
						<tr>
							<td>
								<xsl:value-of select="./@Id"/>
							</td>
							<td>
								<xsl:value-of select="Name"/>
							</td>
							<td>
								<xsl:value-of select="Phone"/>
							</td>
							<td>
								<xsl:value-of select="Department"/>
							</td>
							<td>
								<xsl:value-of select="Street"/>
							</td>
							<td>
								<xsl:value-of select="City"/>
							</td>
							<td>
								<xsl:value-of select="State"/>
							</td>
							<td>
								<xsl:value-of select="Zip"/>
							</td>
							<td>
								<xsl:value-of select="Country"/>
							</td>
						</tr>
					</xsl:for-each>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
